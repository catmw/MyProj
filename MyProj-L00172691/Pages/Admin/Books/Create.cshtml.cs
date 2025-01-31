using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        public CreateModel(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Books.AddAsync(Book);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
