using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.ConsoleClient
{
    public static class ServiceContainer
    {
        static IServiceProvider ServiceProvider;

        public static void ConfigureServices(Action<IServiceCollection> configureServices)
        {
            IServiceCollection services = new ServiceCollection();
            configureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>() =>
            ServiceProvider.GetService<T>();

        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}
