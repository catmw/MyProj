using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProj.Models.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }

        public string? ImageName { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

		public int GenreId { get; set; }
		public Genre? Genre { get; set; }


		public int AuthorId { get; set; }
		public Author? Author { get; set; }
	}
}
