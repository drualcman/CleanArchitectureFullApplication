using CleanArchitectureFullApplication.Main.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureFullApplication.Loggers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLoggers(this IServiceCollection services)
        {
            services.AddScoped<IApplicationStatusLogger, DebugStatusLogger>();
            return services;
        }
    }
}
