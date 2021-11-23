using CleanArchitectureFullApplication.ViewModels;
using System;

namespace CleanArchitectureFullApplication.ConsoleView
{
    public class CreateOrderConsoleView
    {
        readonly CreateOrderViewModel Model;

        public CreateOrderConsoleView(CreateOrderViewModel model) =>
            Model = model;

        public void ExecuteResult()
        {
            System.Console.WriteLine($"Se ha creado la ordern {Model.OrderId}");
        }
    }
}
