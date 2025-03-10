using MyProj.DataAccess.DataAccess;
using MyProj.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;

        public IBookRepo BookRepo { get; private set; }

        public IAuthorRepo AuthorRepo { get; private set; }

        public IGenreRepo GenreRepo { get; private set; }
        public IOrderRepo OrderRepo { get; private set; }
        public IOrderItemRepo OrderItemRepo { get; private set; }
        public IApplicationUserRepo ApplicationUserRepo { get; private set; }
        public IShoppingCartRepo ShoppingCartRepo { get; private set; }
        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            BookRepo = new BookRepo(_dbContext);
            GenreRepo = new GenreRepo(_dbContext);
            AuthorRepo = new AuthorRepo(_dbContext);
            OrderRepo = new OrderRepo(_dbContext);
            OrderItemRepo = new OrderItemRepo(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepo(_dbContext);
            ShoppingCartRepo = new ShoppingCartRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
