using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;

namespace MyProj_L00172691.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public EditModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
		[BindProperty]
		public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _dbContext.Books.Find(id);
        }

        public async Task<IActionResult> OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Update(Book);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }

    }
}
