using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
        }

        //GET: api/portfolio
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userProfile = await _portfolioRepository.GetUserPortfolioAsync(appUser);
            return Ok(userProfile);
        }

        //POST: api/portfolio
        [HttpPost]
        public async Task<IActionResult> AddPortfolio([FromQuery]string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbol(symbol);

            if (stock == null)
                return BadRequest("Stock not found");

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
                return BadRequest("Cannot add same stock to portfolio");

            var portfolioModel = new Portfolio
            {
                StockId = stock.ID,
                AppUserId = appUser.Id
            };

            var response = await _portfolioRepository.CreatePortfolioAsync(portfolioModel);

            if (response == null)
                return StatusCode(500, "Could not create portfolio");
            else
                return Created();
        }

        //DELETE: api/portfolio
        [HttpDelete]
        public async Task<IActionResult> DeletePortfolio([FromQuery]string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            var filterStock = userPortfolio.Where(row=> row.Symbol.ToLower() == symbol.ToLower());

            if (filterStock.Count() == 1)
                await _portfolioRepository.DeleteUserPortfolioAsync(appUser, symbol);
            else
                return BadRequest("Stock not in the portfolio");

            return Ok(filterStock);
        }
        
    }
}
