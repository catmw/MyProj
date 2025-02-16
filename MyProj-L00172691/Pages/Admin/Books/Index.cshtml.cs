
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Book> Books;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public void OnGet()
        {
			Books = _unitOfWork.BookRepo.GetAll(includeProperties: "Author,Genre");

		}
    }
}
