using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public class BookRepo : Repository<Book>, IBookRepo
    {
        private readonly AppDBContext _dbContext;
        public BookRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        Book IBookRepo.GetProductCategory(int id)
        {
            var book = _dbContext.Books.Include(c=>c.Genre).FirstOrDefault(b => b.Id == id);
            return book;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Book book)
        {
			var prodFromDB = _dbContext.Books.
			   FirstOrDefault(prodFromDB => prodFromDB.Id == book.Id);
			prodFromDB.Title = book.Title;
			prodFromDB.GenreId = book.GenreId;
			if (book.ImageName != null)
			{
				prodFromDB.ImageName = book.ImageName;
			}
		}
    }
}
