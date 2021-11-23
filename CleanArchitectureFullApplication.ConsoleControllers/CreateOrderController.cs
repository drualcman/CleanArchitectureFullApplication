using CleanArchitectureFullApplication.ConsoleView;
using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.ConsoleControllers
{
    public class CreateOrderController
    {
        readonly ICreateOrderController Controller;

        public CreateOrderController(ICreateOrderController controller)
        {
            Controller = controller;
        }

        public async Task<CreateOrderConsoleView> CreateOrder(CreateOrderDto order)
        {
            CreateOrderViewModel view = await Controller.CreateOrder(order);
            return new CreateOrderConsoleView(view);
        }
    }
}
