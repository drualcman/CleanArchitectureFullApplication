using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Main.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Dto
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderDtoValidator>();
            return services;
        }
    }
}
