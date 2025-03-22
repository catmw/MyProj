using Microsoft.EntityFrameworkCore;
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

        public int DecrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity -= qty;
            _dbcontext.SaveChanges();
            return shoppingCart.Quantity;
        }

        public void Delete(ShoppingCart obj)
        {
            _dbcontext.ShoppingCart.Remove(obj);
            _dbcontext.SaveChanges();
        }

        public ShoppingCart Get(int id)
        {
            return _dbcontext.ShoppingCart.Include(s => s.Book).FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbcontext.ShoppingCart.Include(s => s.Book).ToList();
        }

        public IEnumerable<ShoppingCart> GetAll(string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCart> GetShoppingCartProducts(string userid)
        {
            var ShoppingCartItem = _dbcontext.ShoppingCart.Where(u => u.ApplicationUserID == userid).Include(p => p.Book).ThenInclude(c => c.Genre);
            return ShoppingCartItem;
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

        public void RemoveAll(IEnumerable<ShoppingCart> items)
        {
            _dbcontext.RemoveRange(items);
            _dbcontext.SaveChanges();
        }

        public void Update(ShoppingCart obj)
        {
            _dbcontext.ShoppingCart.Update(obj);
            _dbcontext.SaveChanges();
        }
    }
}
