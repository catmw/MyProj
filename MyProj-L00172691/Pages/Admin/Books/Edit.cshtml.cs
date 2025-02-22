using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using MyProj.Models.Models;
using Services;

namespace MyProj_L00172691.Pages.Admin.Books
{
    public class EditModel : PageModel
    {
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<SelectListItem> AuthorList { get; set; }
		public IEnumerable<SelectListItem> GenreList { get; set; }
		public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
			_unitOfWork = unitOfWork;
		}
		[BindProperty]
		public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookRepo.Get(id);
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
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var existingBook = _unitOfWork.BookRepo.Get(Book.Id);
			if (existingBook == null)
			{
				return NotFound();
			}

			string wwwRootFolder = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;

			if (files.Count > 0)
			{
				string new_filename = Guid.NewGuid().ToString();
				var upload = Path.Combine(wwwRootFolder, @"Images\Books");
				var extension = Path.GetExtension(files[0].FileName);

				using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
				{
					files[0].CopyTo(fileStream);
				}
				Book.ImageName = @"\Images\Books\" + new_filename + extension;
			}
			else
			{
				Book.ImageName = existingBook.ImageName;
			}
			existingBook.Title = Book.Title;
			existingBook.AuthorId = Book.AuthorId;
			existingBook.GenreId = Book.GenreId;
			existingBook.ImageName = Book.ImageName;
			existingBook.Price = Book.Price;
			existingBook.Description = Book.Description;

			_unitOfWork.BookRepo.Update(existingBook);
			_unitOfWork.Save();

			return RedirectToPage("Index");
		}

	}
}
