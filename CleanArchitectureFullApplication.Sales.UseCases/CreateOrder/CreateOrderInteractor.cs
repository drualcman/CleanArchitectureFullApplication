using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Sales.Entities.Aggregates;
using CleanArchitectureFullApplication.Sales.Events;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderWritableRepository Repository;
        readonly ICreateOrderOutputPort Output;
        readonly IEventHub<SpecialOrderCreatedEvent> Events;
        public CreateOrderInteractor(
            IOrderWritableRepository repository,
            ICreateOrderOutputPort output,
            IEventHub<SpecialOrderCreatedEvent> events)
        {
            Repository = repository;
            Output = output;
        }            

        public ValueTask Handle(string order)
        {
            OrderAggregate aggregate = new OrderAggregate();

            Repository.CreateOrder(aggregate);

            SpecialOrderCreatedEvent specialOrder = 
                new SpecialOrderCreatedEvent(aggregate.Id, aggregate.OrderDetails.Count);
            Events.Raise(specialOrder);

            Output.Handle(aggregate.Id);

            return ValueTask.CompletedTask;
        }
    }
}
