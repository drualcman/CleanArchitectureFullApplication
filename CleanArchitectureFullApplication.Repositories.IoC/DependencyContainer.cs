using CleanArchitectureFullApplication.EfCore.Repositories;
using CleanArchitectureFullApplication.EFCore.DataContext;
using CleanArchitectureFullApplication.Main.Interfaces;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Repositories.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,
            IConfiguration configuration, string connectionName)
        {
            services.AddDbContext<CleanArchitectureSalesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(connectionName)));
            services.AddScoped<ILogWritableRepository, LogWritableRepository>();
            services.AddScoped<IOrderWritableRepository, OrderWritableRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
