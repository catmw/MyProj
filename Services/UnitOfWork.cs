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

        public UnitOfWork(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            BookRepo = new BookRepo(_dbContext);
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
