using Microsoft.EntityFrameworkCore;
using MyProj.Models.Models;

namespace MyProj.DataAccess.DataAccess
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>().HasData(
				new Book { Id = 1, Title="The Travelling Cat Chronicles", Author="Hiro Arikawa", Genre="Contemporary" },
				new Book { Id = 2, Title = "Small Things Like These", Author = "Clair Keegan", Genre = "Historical" },
				new Book { Id = 3, Title = "Hidden Pictures", Author = "Jason Rekulak", Genre = "Mystery" },
				new Book { Id = 4, Title = "The Story of Kao Yu", Author = "Peter Beagle", Genre = "Fantasy" },
				new Book { Id = 5, Title = "Who Was Changed and Who Was Dead", Author = "Barbara Comyns", Genre = "Classics" }
			);
		}
	}

}
