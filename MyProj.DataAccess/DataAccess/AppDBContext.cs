using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProj.Models.Models;

namespace MyProj.DataAccess.DataAccess
{
    public class AppDBContext :IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Sci-Fi" },
                new Genre { Id = 3, Name = "Romance" },
                new Genre { Id = 4, Name = "Contemporary" },
                new Genre { Id = 5, Name = "Horror" }
            );
 
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Hiro Arikawa" },
                new Author { Id = 2, Name = "Gabrielle Zevin" },
                new Author { Id = 3, Name = "Jane Austen" },
                new Author { Id = 4, Name = "Stephen King" },
                new Author { Id = 5, Name = "George R. R. Martin" }
            );
        }
    }

}
