using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;
using System.Security.Claims;

namespace MyProj_L00172691.Pages.Customer.Home
{
    [Authorize(Roles = "Customer, Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }
        public Book Book { get; set; }
        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //Book = _unitOfWork.BookRepo.Get(id);
            ShoppingCart = new ShoppingCart
            {
                ApplicationUserID = claim.Value,
                Quantity = 1,
                Book = _unitOfWork.BookRepo.GetProductCategory(id),
                BookId = id
            };
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCartRepo.IncrementItem(ShoppingCart.ApplicationUserID, ShoppingCart.BookId);
                if(shoppingCartFromDb == null)
                {
                    _unitOfWork.ShoppingCartRepo.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ShoppingCartRepo.IncrementQty(shoppingCartFromDb, ShoppingCart.Quantity);
                }

                    return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
