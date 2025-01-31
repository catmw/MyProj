using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj_L00172691.DataAccess;
using MyProj_L00172691.Models;

namespace MyProj_L00172691.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public DeleteModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
		[BindProperty]
		public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _dbContext.Books.Find(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
			var Book = _dbContext.Books.Find(id);
			if (Book != null)
			{
				_dbContext.Books.Remove(Book);
				await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
