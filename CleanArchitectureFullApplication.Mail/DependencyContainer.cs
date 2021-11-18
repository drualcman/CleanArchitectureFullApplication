using CleanArchitectureFullApplication.Main.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Mail
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMailService(this IServiceCollection services)
        {
            services.AddTransient<IMailService, MailService>();
            return services;
        }
    }
}
