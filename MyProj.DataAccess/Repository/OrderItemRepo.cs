using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly AppDBContext _dbcontext;
        public OrderItemRepo(AppDBContext context)
        {
            _dbcontext = context;
        }
        public void Add(OrderItem orderItem)
        {
            _dbcontext.OrderItems.Add(orderItem);
            _dbcontext.SaveChanges();
        }
    }
}
