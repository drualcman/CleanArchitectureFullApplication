using CleanArchitectureFullApplication.Main.Events;
using System;

namespace CleanArchitectureFullApplication.Sales.Events
{
    public class SpecialOrderCreatedEvent : IEvent
    {
        public int OrderID { get; }
        public int ProductsCount { get; }
        public SpecialOrderCreatedEvent(int orderId, int productsCount) =>
            (OrderID, ProductsCount) = (orderId, productsCount);
    }
}
