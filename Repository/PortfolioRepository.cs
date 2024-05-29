using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<NDStockDTO>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
                .Select(stock => new NDStockDTO
                {
                    ID = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap
                }).ToListAsync();
        }

        public async Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeleteUserPortfolioAsync(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(row=> row.AppUserId == appUser.Id && row.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null)
                return null;

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }
    }
}
