using CleanArchitectureFullApplication.ConsoleView;
using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.ConsoleControllers
{
    public class GetOrdersByDateController 
    {
        readonly IGetOrdersByDateController Controller;

        public GetOrdersByDateController(IGetOrdersByDateController controller)
        {
            Controller = controller;
        }

        public async ValueTask<OrdersConsoleView> GetOrdersByDate(GetOrdersByDateDto date)
        {
            OrdersViewModel view = await Controller.GetOrderByDate(date);
            return new OrdersConsoleView(view);
        }
    }
}
