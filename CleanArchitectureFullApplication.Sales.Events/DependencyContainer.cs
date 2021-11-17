using CleanArchitectureFullApplication.Main.Events;
using Microsoft.Extensions.DependencyInjection;

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
