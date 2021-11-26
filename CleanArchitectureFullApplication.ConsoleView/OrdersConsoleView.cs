using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.ConsoleView
{
    public class OrdersConsoleView
    {
        readonly OrdersViewModel Model;

        public OrdersConsoleView(OrdersViewModel model)
        {
            Model = model;
        }

        public void ExecuteResult()
        {
            foreach (OrderDto order in Model.Orders)
            {
                Console.WriteLine($"Orden: {order.Id}");
                Console.WriteLine($"Cliente: {order.CustomerName}");
                Console.WriteLine($"Fecha: {order.OrderDate.Date}");
                Console.WriteLine("Direccion de envio:");
                Console.WriteLine($"\t{order.ShipAddress}");
                Console.WriteLine($"\t{order.ShipCity}");
                Console.WriteLine($"\t{order.ShipPostalCode} {order.ShipCountry}");
                Console.WriteLine(new string('-', 60));
                foreach (var product in order.OrderDetails)
                {
                    Console.WriteLine("{0,3}{1,-40}{2,6:C2}{3,4}", 
                        product.ProductId, product.ProductName, product.UnitPrice, product.Quantity);
                }
                Console.WriteLine(new string('-', 60));
                Console.WriteLine();
            }
        }
    }
}
