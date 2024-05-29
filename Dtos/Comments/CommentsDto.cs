﻿namespace api.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        public string? AppUserId { get; set; }
    }
}
