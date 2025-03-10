using MyProj.DataAccess.DataAccess;
using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly AppDBContext _dbContext;

        public ApplicationUserRepo(AppDBContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }

        public ApplicationUser Get(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null!;
            }
            else
            {
                var user = _dbContext.Users.Where(u => u.Id == s).FirstOrDefault();
                return user as ApplicationUser ?? throw new InvalidCastException("The user could not be cast to ApplicationUser.");
            }
        }
    }
}

