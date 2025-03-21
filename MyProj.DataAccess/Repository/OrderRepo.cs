using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDBContext _dbcontext;

        public OrderRepo(AppDBContext context)
        {
            _dbcontext = context;
        }
        public void Add(Order order)
        {
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
        }
    }
}
