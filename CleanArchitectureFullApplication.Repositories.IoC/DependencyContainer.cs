using CleanArchitectureFullApplication.Dapper.Repository;
using CleanArchitectureFullApplication.EfCore.Repositories;
using CleanArchitectureFullApplication.EFCore.DataContext;
using CleanArchitectureFullApplication.Main.Interfaces;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

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

            services.AddScoped<IDbConnection>( provider =>
                new SqlConnection(configuration.GetConnectionString(connectionName)));

            services.AddScoped<IOrderReadableRepository, OrderReadableRepository>();
            return services;
        }
    }
}
