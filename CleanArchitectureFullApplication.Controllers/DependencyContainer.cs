using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSalesControllers(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController, CreateOrderController>();
            return services;
        }
    }
}
