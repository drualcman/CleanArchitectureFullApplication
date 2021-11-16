using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Validators;
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
        readonly IValidator<CreateOrderDto> Validator;
        public CreateOrderInteractor(
            IOrderWritableRepository repository,
            ICreateOrderOutputPort output,
            IEventHub<SpecialOrderCreatedEvent> events,
            IValidator<CreateOrderDto> validator)
        {
            Repository = repository;
            Output = output;
            Events = events;
            Validator = validator;
        }            

        public ValueTask Handle(CreateOrderDto order)
        {
            ValidationResult validation = Validator.Validate(order);
            if (validation.IsValid)
            {

                OrderAggregate aggregate = new OrderAggregate();

                aggregate.OrderDate = DateTime.Now;
                aggregate.ShipAddress = order.ShipAddress;
                aggregate.ShipCity = order.ShipCity;
                aggregate.ShipCountry = order.ShipCountry;
                aggregate.ShipPostalCode = order.ShipPostalCode;
                aggregate.CustomerId = order.CustomerId;

                Repository.CreateOrder(aggregate);

                SpecialOrderCreatedEvent specialOrder =
                    new SpecialOrderCreatedEvent(aggregate.Id, aggregate.OrderDetails.Count);
                Events.Raise(specialOrder);

                Output.Handle(aggregate.Id);
            }
            else
            {
                
            }
            return ValueTask.CompletedTask;
        }
    }
}
