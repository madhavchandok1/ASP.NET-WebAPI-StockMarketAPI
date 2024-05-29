using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<List<NDStockDTO>> GetUserPortfolioAsync(AppUser user);

        public Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio);

        public Task<Portfolio> DeleteUserPortfolioAsync(AppUser appUser, string symbol);
    }
}
