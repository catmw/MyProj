using MyProj.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepo BookRepo { get; }

        void Save();

        IAuthorRepo AuthorRepo { get; }

        IGenreRepo GenreRepo { get; }
        IOrderRepo OrderRepo { get; }
        IOrderItemRepo OrderItemRepo { get; }
        IApplicationUserRepo ApplicationUserRepo { get; }
        IShoppingCartRepo ShoppingCartRepo { get; }
    }
}
