using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public interface IBookRepo : IRepository<Book>
    {
        void SaveAll();
        public void Update(Book book);
        Book GetProductCategory(int id);
    }
}
