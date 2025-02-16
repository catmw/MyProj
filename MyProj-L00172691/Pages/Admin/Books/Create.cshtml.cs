using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Books
{
	[BindProperties]
	public class CreateModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_unitOfWork = unitOfWork;
		}
		[BindProperty]
		public Book Book { get; set; }
		public IEnumerable<SelectListItem> AuthorList { get; set; }
		public IEnumerable<SelectListItem> GenreList { get; set; }
		public void OnGet()
		{
			AuthorList = _unitOfWork.AuthorRepo.GetAll()
				.Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});

			GenreList = _unitOfWork.GenreRepo.GetAll()
				.Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.Id.ToString()
				});

		}

		public IActionResult OnPost()
		{
			string wwwRootFolder = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			string new_filename = Guid.NewGuid().ToString();

			var upload = Path.Combine(wwwRootFolder, @"Images\Books");

			var extension = Path.GetExtension(files[0].FileName);
			using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
			{
				files[0].CopyTo(fileStream);
			}

			Book.ImageName = @"\Images\Books\" + new_filename + extension;
			if (ModelState.IsValid)
			{
				_unitOfWork.BookRepo.Add(Book);
				_unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
