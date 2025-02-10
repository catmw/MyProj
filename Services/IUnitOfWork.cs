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
    }
}
