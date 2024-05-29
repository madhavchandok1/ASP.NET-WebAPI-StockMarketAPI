namespace api.Dtos.Comments
{
    public class WACommentDTO
    {
        public string Title { get; set; }
        
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
