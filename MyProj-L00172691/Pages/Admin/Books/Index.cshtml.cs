
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookRepo _bookRepo;
        public IEnumerable<Book> Books;
        public IndexModel(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public void OnGet()
        {
            Books = _bookRepo.GetAll();
        }
    }
}
