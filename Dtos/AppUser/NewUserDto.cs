using System.ComponentModel.DataAnnotations;

namespace api.Dtos.AppUser
{
    public class NewUserDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Token { get; set; }
    }
}
