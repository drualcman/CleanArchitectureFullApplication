using CleanArchitectureFullApplication.Sales.UseCases.CreateOrder;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateOrderInputPort, CreateOrderInteractor>();
            return services;
        }
    }
}
