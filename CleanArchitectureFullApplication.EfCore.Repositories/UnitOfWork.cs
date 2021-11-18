using CleanArchitectureFullApplication.EFCore.DataContext;
using CleanArchitectureFullApplication.Main.Exceptions;
using CleanArchitectureFullApplication.Main.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.EfCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CleanArchitectureSalesContext Context;
        readonly IApplicationStatusLogger Logger;
        public UnitOfWork(CleanArchitectureSalesContext context, IApplicationStatusLogger logger) =>
            (Context, Logger) = (context, logger);
        public async ValueTask<int> SaveChanges()
        {
            int result;
            try
            {
                result = await Context.SaveChangesAsync();
                Logger.Log($"Registros modificados {result}");
            }
            catch (DbUpdateException ex)
            {
                Logger.Log(ex.InnerException?.Message ?? ex.Message);
                throw new UpdateException(
                    ex.InnerException?.Message ?? ex.Message,
                    ex.Entries.Select(e=>e.Entity.GetType().Name).ToList()
                    );
            }
            catch (Exception ex)
            {
                Logger.Log(ex.InnerException?.Message ?? ex.Message);
                throw new GeneralException("Error al persistur los cambios", ex.Message);
            }

            return result;
        }
    }
}
