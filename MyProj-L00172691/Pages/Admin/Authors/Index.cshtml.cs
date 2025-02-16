using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;


namespace MyProj_L00172691.Pages.Admin.Authors
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Author> Authors;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		public Author Author { get; set; }
		public void OnGet()
        {
            Authors = _unitOfWork.AuthorRepo.GetAll();
        }
    }
}
