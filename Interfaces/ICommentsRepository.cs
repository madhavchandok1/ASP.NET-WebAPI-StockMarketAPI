using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentsRepository: IRepository<Comments>
    {
        public Task<List<Comments>> GetAllAsync(CommentQueryObject query);

        public Task<Comments?> UpdateAsync(int id, Comments comment);
    }
}
