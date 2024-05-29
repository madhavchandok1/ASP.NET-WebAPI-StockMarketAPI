using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comments
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters atleast.")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 80 characters long.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 characters atleast.")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters long.")]
        public string Content { get; set; } = string.Empty;
    }
}
