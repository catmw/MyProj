using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> listOfBooks { get; set; }

        public IEnumerable<Genre> listOfGenres { get; set; }
        [BindProperty(SupportsGet =true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            listOfBooks = _unitOfWork.BookRepo.GetAll();
            listOfGenres = _unitOfWork.GenreRepo.GetAll();
			if (!string.IsNullOrEmpty(SearchString))
			{
				listOfBooks = listOfBooks.Where(p => p.Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
			}
		}
    }
}
