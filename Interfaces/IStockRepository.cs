using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository: IRepository<Stock>
    {
        public Task<List<Stock>> GetAllAsync(StockQueryObject query);

        public Task<Stock?> GetBySymbol(string symbol);

        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);
        
        public Task<bool> IsStockExists(int id);
    }
}
