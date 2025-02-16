using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Genres
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Genre Genre { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GenreRepo.Add(genre);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
