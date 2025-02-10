using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		[BindProperty]
		public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookRepo.Get(id);
        }

        public IActionResult OnPost(Book Book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookRepo.Update(Book);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }

    }
}
