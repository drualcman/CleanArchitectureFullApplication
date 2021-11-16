using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.Events
{
    public class SpecialOrderCreatedEventHandler : IEventHandler<SpecialOrderCreatedEvent>
    {
        readonly IMailService Service;

        public SpecialOrderCreatedEventHandler(IMailService service) => 
            Service = service;

        public ValueTask Handle(SpecialOrderCreatedEvent order)
        {
            return Service.Send($"Orden {order.OrderID} con {order.ProductsCount} productos.");
        }
    }
}
