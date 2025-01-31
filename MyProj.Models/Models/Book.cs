using System.ComponentModel.DataAnnotations;

namespace MyProj.Models.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required] 
        public string? Author { get; set; }
        [Required]
        public string? Genre { get; set; }
    }
}
