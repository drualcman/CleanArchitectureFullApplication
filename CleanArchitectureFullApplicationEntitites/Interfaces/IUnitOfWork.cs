﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Entitites.Interfaces
{
    public interface IUnitOfWork
    {
        ValueTask<int> SaveChanges();
    }
}