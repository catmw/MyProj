using MyProj.DataAccess.DataAccess;
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
    }
}
