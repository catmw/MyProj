using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Authors
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Author Author { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Author author)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AuthorRepo.Add(author);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
