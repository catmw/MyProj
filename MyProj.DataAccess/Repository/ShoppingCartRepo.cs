using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public class ShoppingCartRepo : IShoppingCartRepo
    {
        private readonly AppDBContext _dbcontext;

        public ShoppingCartRepo(AppDBContext context)
        {
            _dbcontext = context;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _dbcontext.ShoppingCart.Add(shoppingCart);
            _dbcontext.SaveChanges();
        }

        public void Delete(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCart> GetAll(string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart IncrementItem(string userid, int id)
        {
            var shoppingCartItem = _dbcontext.ShoppingCart.Where(p=>p.BookId == id && p.ApplicationUserID == userid).FirstOrDefault();
            return shoppingCartItem;
        }

        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbcontext.SaveChanges();
            return shoppingCart.Quantity;
        }

        public void Update(ShoppingCart obj)
        {
            throw new NotImplementedException();
        }
    }
}
