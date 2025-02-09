using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookRepo _bookRepo;
        public EditModel(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
		[BindProperty]
		public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _bookRepo.Get(id);
        }

        public IActionResult OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Update(Book);
                _bookRepo.SaveAll();
            }
            return RedirectToPage("Index");
        }

    }
}
