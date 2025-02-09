using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepo _bookRepo;
        public CreateModel(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Add(Book);
                _bookRepo.SaveAll();
            }
            return RedirectToPage("Index");
        }
    }
}
