using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;


namespace MyProj_L00172691.Pages.Admin.Genres
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Genre> Genres;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		public Genre Genre { get; set; }
		public void OnGet()
        {
            Genres = _unitOfWork.GenreRepo.GetAll();
        }
    }
}
