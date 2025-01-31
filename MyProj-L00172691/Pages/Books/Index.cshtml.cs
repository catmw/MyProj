
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj_L00172691.DataAccess;
using MyProj_L00172691.Models;

namespace MyProj_L00172691.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public IEnumerable<Book> Books;
        public IndexModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Books = _dbContext.Books;
        }
    }
}
