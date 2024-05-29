using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        readonly ApplicationDbContext _context;

        public CommentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Comments>> GetAllAsync(CommentQueryObject query)
        {
            var comments = _context.Comments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                comments = comments.Where(row => row.Stock.Symbol == query.Symbol);
            }
            else if (query.IsDescending)
            {
                comments = comments.OrderByDescending(row=> row.CreatedOn);
            }

            return await comments.ToListAsync();
        }

        public Task<Comments?> GetByIdAsync(int id)
        {
            var comment = _context.Comments.FirstOrDefaultAsync(row=> row.Id == id);
            if (comment == null)
                return null;
            return comment;
        }

        public async Task<Comments?> CreateAsync(Comments comments)
        {
            await _context.Comments.AddAsync(comments);
            await _context.SaveChangesAsync();
            return comments;
        }

        public async Task<Comments?> UpdateAsync(int id, Comments comment)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(row=>row.Id == id);
            if (existingComment == null)
                return null;

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;
            existingComment.UpdatedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            
            return existingComment;
        }

        public async Task<Comments?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(row => row.Id == id);
            if (comment == null)
                return null;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
