using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.Events
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEventsHandlers(this IServiceCollection services)
        {
            services.AddScoped<IEventHandler<SpecialOrderCreatedEvent>, SpecialOrderCreatedEventHandler>();
            return services;
        }
    }
}
