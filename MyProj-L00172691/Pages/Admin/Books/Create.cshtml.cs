using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookRepo.Add(Book);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
