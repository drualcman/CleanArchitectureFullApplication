using CleanArchitectureFullApplication.EFCore.DataContext;
using CleanArchitectureFullApplication.Main.Entities;
using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.EfCore.Repositories
{
    public class LogWritableRepository : ILogWritableRepository
    {
        readonly CleanArchitectureSalesContext Context;
        public LogWritableRepository(CleanArchitectureSalesContext context) =>
            Context = context;
        
        public void Add(Log log) => Context.Add(log);        

        public void Add(string description) =>
            Add(new Log(description));
    }
}
