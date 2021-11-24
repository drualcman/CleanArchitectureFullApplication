using CleanArchitectureFullApplication.ConsoleControllers;
using CleanArchitectureFullApplication.ConsoleView;
using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto;
using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Loggers;
using CleanArchitectureFullApplication.Mail;
using CleanArchitectureFullApplication.Main;
using CleanArchitectureFullApplication.Presenters;
using CleanArchitectureFullApplication.Repositories.IoC;
using CleanArchitectureFullApplication.Sales.Events;
using CleanArchitectureFullApplication.Sales.UseCases;
using System;
using System.Collections.Generic;

namespace CleanArchitectureFullApplication.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceContainer.ConfigureServices(services =>
            {
                services.AddMainServices();
                services.AddLoggers();
                services.AddEventsHandlers();
                services.AddMailService();
                services.AddRepositories(ServiceContainer.Configuration, "CleanSalesDb");
                services.AddUseCases();
                services.AddValidators();
                services.AddPresenter();
                services.AddSalesControllers();
            });
            CreateOrder();
        }

        static void CreateOrder()
        {
            CreateOrderConsoleController controller = new CreateOrderConsoleController(
                ServiceContainer.GetService<ICreateOrderController>());
            try
            {
                CreateOrderDto order = new CreateOrderDto
                {
                    CustomerId = "ANTON",
                    ShipAddress = "cualquiera",
                    ShipCity = "una ciudad",
                    ShipCountry = "filipinas",
                    ShipPostalCode = "12345",
                    OrderDetails = new List<CreateOrderDetailDto>
                    {
                        new CreateOrderDetailDto
                        {
                            ProdcutId = 1,
                            UnitPrice = 1,
                            Quantity = 1,
                        }
                    }
                };
                CreateOrderConsoleView view = controller.CreateOrder(order).Result;
                view.ExecuteResult();
            }
            catch (Exception ex)
            {
                new ErrorConsoleView(ex?.InnerException ?? ex).ExecuteResult();
            }
        }
    }
}
