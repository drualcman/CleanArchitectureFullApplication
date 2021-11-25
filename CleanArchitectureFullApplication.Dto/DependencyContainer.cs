using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Dto
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderDtoValidator>();
            services.AddScoped<IValidator<GetOrdersByDateDto>, GetOrdersByDateDtoValidator>();
            return services;
        }
    }
}
