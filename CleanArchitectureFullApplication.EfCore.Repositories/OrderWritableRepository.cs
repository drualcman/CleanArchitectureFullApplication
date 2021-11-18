using CleanArchitectureFullApplication.EFCore.DataContext;
using CleanArchitectureFullApplication.Sales.Entities.Aggregates;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using System;

namespace CleanArchitectureFullApplication.EfCore.Repositories
{
    public class OrderWritableRepository : IOrderWritableRepository
    {
        readonly CleanArchitectureSalesContext Context;
        public OrderWritableRepository(CleanArchitectureSalesContext context) =>
            Context = context;

        public void CreateOrder(OrderAggregate order)
        {
            Context.Add(order);
            foreach (var item in order.OrderDetails)
            {
                Context.Add(new OrderDetail
                {
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Order = order
                });
            }
        }
    }
}
