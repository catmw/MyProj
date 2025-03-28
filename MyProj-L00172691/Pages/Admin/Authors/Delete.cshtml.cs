using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		[BindProperty]
		public Author Author { get; set; }
        public void OnGet(int id)
        {
            Author = _unitOfWork.AuthorRepo.Get(id);
        }

        public IActionResult OnPost(Author author)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AuthorRepo.Delete(author);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}
