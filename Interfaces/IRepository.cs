using api.Models;

namespace api.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetByIdAsync(int id);

        public Task<T?> CreateAsync(T entity);

        public Task<T?> DeleteAsync(int id);
    }
}
