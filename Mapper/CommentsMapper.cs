using api.Dtos.Comments;
using api.Models;

namespace api.Mapper
{
    public static class CommentsMapper
    {
        public static CommentDto toCommentsDto(this Comments comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn,
                StockId = comment.StockId,
                AppUserId = comment.AppUserId
            };
        }

        public static WACommentDTO toWACommentDTO(this Comments comment)
        {
            return new WACommentDTO
            {
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn
            };
        }

        public static Comments fromCreateToComment(this CreateCommentDto createComment, int stockId, string appUserId)
        {
            return new Comments
            {
                Title = createComment.Title,
                Content = createComment.Content,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                StockId = stockId,
                AppUserId = appUserId
            };
        }

        public static Comments fromUpdateToComment(this UpdateCommentDto updateCommentDto)
        {
            return new Comments
            {
                Title = updateCommentDto.Title,
                Content = updateCommentDto.Content
            };
        }
    }
}
