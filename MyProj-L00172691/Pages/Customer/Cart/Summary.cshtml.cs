using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProj.Models.Models;
using Services;
using System.Security.Claims;

namespace MyProj_L00172691.Pages.Customer.Cart
{
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Order Order { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Order = new Order();
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userid = claim.Value;
            ShoppingCartList = _unitOfWork.ShoppingCartRepo.GetShoppingCartProducts(userid);
            foreach (var item in ShoppingCartList)
            {
                Order.TotalAmtDue += item.Book.Price * item.Quantity;
            }
            ApplicationUser applicationUser = _unitOfWork.ApplicationUserRepo.Get(claim.Value);
            Order.CustomerName = applicationUser.FirstName + "" + applicationUser.LastName;
            Order.DateOfOrder = DateTime.Now;
            Order.PhoneNumber = applicationUser.PhoneNumber;
        }
        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userid = claim.Value;
            ShoppingCartList = _unitOfWork.ShoppingCartRepo.GetShoppingCartProducts(userid).ToList();
            foreach (var item in ShoppingCartList)
            {
                Order.TotalAmtDue += (item.Book.Price * item.Quantity);
            }
            ApplicationUser applicationUser = _unitOfWork.ApplicationUserRepo.Get(claim.Value);
            Order.UserId = claim.Value;
            Order.CustomerName = applicationUser.FirstName + " " + applicationUser.LastName;
            Order.DateOfOrder = DateTime.Now;
            Order.PhoneNumber = applicationUser.PhoneNumber;
            _unitOfWork.OrderRepo.Add(Order);
            _unitOfWork.Save();

            foreach (var item in ShoppingCartList)
            {
                OrderItem orderItems = new OrderItem
                {
                    OrderId = Order.ID,
                    Book = item.Book,
                    QtyOrdered = item.Quantity,

                };
                _unitOfWork.OrderItemRepo.Add(orderItems);
            }
            _unitOfWork.ShoppingCartRepo.RemoveAll(ShoppingCartList);
            _unitOfWork.Save();
            return RedirectToPage("OrderPlaced");
        }
    }
}
