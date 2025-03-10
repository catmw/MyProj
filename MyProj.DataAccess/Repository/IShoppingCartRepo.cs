using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
        ShoppingCart IncrementItem(string userid, int id);
        int IncrementQty(ShoppingCart shoppingCart, int qty);
        void Add(ShoppingCart shoppingCart);
    }
}
