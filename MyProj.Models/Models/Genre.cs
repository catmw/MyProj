using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.Models.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }
	}
}
