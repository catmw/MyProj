﻿using MyProj.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.DataAccess.Repository
{
    public interface IGenreRepo : IRepository<Genre>
    {
        void SaveAll();
    }
}
