using CleanArchitectureFullApplication.Sales.UseCases.Ports.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenter(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
            return services;
        }
    }
}
