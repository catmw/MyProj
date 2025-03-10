using MyProj.DataAccess.DataAccess;
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
    }
}
