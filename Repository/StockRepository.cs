using api.Controllers;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Stock>> GetAllAsync(StockQueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s=> s.CompanyName.Contains(query.CompanyName)); 
            }
            
            else if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s=> s.Symbol.Contains(query.Symbol));
            }

            else if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(row=> row.Symbol) : stocks.OrderBy(stocks=> stocks.Symbol);
                }
            }

            int skipNumber = (query.PageNumber - 1) * query.PageSize;
            
            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(row => row.ID == id);
            return stock;
        }

        public async Task<Stock?> GetBySymbol(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(row=> row.Symbol.ToLower() == symbol.ToLower());
        }

        public async Task<Stock?> CreateAsync(Stock entity)
        {
            if (entity == null)
                return null;
            await _context.Stocks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(row => row.ID == id);
            if (existingStock == null)
                return null;

            existingStock.Symbol = updateStockRequestDto.Symbol;
            existingStock.CompanyName = updateStockRequestDto.CompanyName;
            existingStock.Purchase = updateStockRequestDto.Purchase;
            existingStock.LastDiv = updateStockRequestDto.LastDiv;
            existingStock.Industry = updateStockRequestDto.Industry;
            existingStock.MarketCap = updateStockRequestDto.MarketCap;

            await _context.SaveChangesAsync();

            return existingStock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(row => row.ID == id);
            if (stock == null)
                return null;
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;

        }

        public async Task<bool> IsStockExists(int id)
        {
            return await _context.Stocks.AnyAsync(row => row.ID == id);
        }
    }
}
