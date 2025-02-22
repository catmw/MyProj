using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookRepo.Get(id);
        }
    }
}
