using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.EFCore.DataContext
{
    internal class CleanArchitectureSalesContextFactory :
        IDesignTimeDbContextFactory<CleanArchitectureSalesContext>
    {
        public CleanArchitectureSalesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CleanArchitectureSalesContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=CleanSales");
            return new CleanArchitectureSalesContext(optionsBuilder.Options);
            
        }
    }
}
