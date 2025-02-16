using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Genres
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		[BindProperty]
		public Genre Genre { get; set; }
        public void OnGet(int id)
        {
            Genre = _unitOfWork.GenreRepo.Get(id);
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepo.Delete(genre);
                _unitOfWork.Save();
            }

            return RedirectToPage("Index");
        }
    }
}
