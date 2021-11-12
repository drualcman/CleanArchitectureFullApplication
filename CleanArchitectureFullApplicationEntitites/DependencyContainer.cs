using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMainServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEventHub<>), typeof(EventHub<>));
            services.AddSingleton(typeof(IValidatorService<>), typeof(ValidatorService<>));
            return services;
        }
    }
}
