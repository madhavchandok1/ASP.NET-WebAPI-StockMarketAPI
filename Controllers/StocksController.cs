using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        // GET: api/Stocks
        [HttpGet]
        
        public async Task<IActionResult> GetStocks([FromQuery]StockQueryObject query)
        {
            //Get the list of stocks from the DB
            var stocks = await _stockRepository.GetAllAsync(query);

            var stockDto = stocks.Select(row => row.toStockDto()).ToList();

            return Ok(stockDto);
        }

        //GET: api/Stocks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById([FromRoute] int id) 
        { 
            //Find the first stock with specified ID from the DB
            var stock = await _stockRepository.GetByIdAsync(id);
            
            if (stock == null)
                return NotFound();

            return Ok(stock.toStockDto());

        }

        //POST: api/Stocks/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockDto)
        {
            if (createStockDto == null)
                return NotFound("Please pass valid stock data");

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var stock = createStockDto.toStockFromCreateStockDto();

            await _stockRepository.CreateAsync(stock);
           
            return CreatedAtAction(nameof(GetStockById), new { id = stock.ID }, stock.toStockDto());
        }

        //PUT: api/Stocks/update/{id}
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdateStockRequestDto updateStockRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stock = await _stockRepository.UpdateAsync(id, updateStockRequestDto);
            if(stock == null)
                return NotFound();

            return Ok(stock.toStockDto());
        }

        //DELETE: api/Stocks/delete/{id}
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            //Searching for stock with specific ID in the DB
            var stock = await _stockRepository.DeleteAsync(id);
            if (stock == null)
                return NotFound();

            return Ok(stock.toStockDto());
        }

    }
}
