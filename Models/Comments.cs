using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Comments")]
    public class Comments
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; }

        public int? StockId { get; set; }
        
        public Stock? Stock { get; set; }

        public string AppUserId {  get; set; }

        public AppUser AppUser { get; set; }
    }
}
