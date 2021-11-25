using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto;
using CleanArchitectureFullApplication.Loggers;
using CleanArchitectureFullApplication.Mail;
using CleanArchitectureFullApplication.Main;
using CleanArchitectureFullApplication.Presenters;
using CleanArchitectureFullApplication.Repositories.IoC;
using CleanArchitectureFullApplication.Sales.Events;
using CleanArchitectureFullApplication.Sales.UseCases;
using CleanArchitectureFullApplication.WebExceptionPresenters.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(Filters.Register);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitectureFullApplication.WebApi", Version = "v1" });
            });
            services.AddMainServices();
            services.AddLoggers();
            services.AddEventsHandlers();
            services.AddMailService();
            services.AddRepositories(Configuration, "CleanSalesDb");
            services.AddUseCases();
            services.AddValidators();
            services.AddPresenter();
            services.AddSalesControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("default", config =>
                {
                    config.AllowAnyMethod();
                    config.AllowAnyOrigin();
                    config.AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitectureFullApplication.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("default");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
