using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Main.Events;
using CleanArchitectureFullApplication.Main.Interfaces;
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
        readonly IOrderWritableRepository OrderRepository;
        readonly ILogWritableRepository LogRepository;
        readonly IUnitOfWork UnitOfwork;
        readonly ICreateOrderOutputPort Output;
        readonly IEventHub<SpecialOrderCreatedEvent> Events;
        readonly IEnumerable<IValidator<CreateOrderDto>> Validators;
        readonly IValidatorService<CreateOrderDto> Validator;
        readonly IApplicationStatusLogger ApplicationStatusLogger;
        public CreateOrderInteractor(
            IOrderWritableRepository oderRepository,
            ILogWritableRepository logRepository,
            IUnitOfWork unitOfwork,
            ICreateOrderOutputPort output,
            IEventHub<SpecialOrderCreatedEvent> events,
            IEnumerable<IValidator<CreateOrderDto>> validators,
            IValidatorService<CreateOrderDto> validator,
            IApplicationStatusLogger applicationStatusLogger)
        {
            OrderRepository = oderRepository;
            LogRepository = logRepository;
            UnitOfwork = unitOfwork;
            Output = output;
            Events = events;
            Validators = validators;
            Validator = validator;
            ApplicationStatusLogger = applicationStatusLogger;
        }

        public async ValueTask Handle(CreateOrderDto order)
        {
            //clausula guard: solo continue el codigo si cumple la validacion
            //por eso no necesita una propiedad IsValid
            Validator.Validate(order, Validators, ApplicationStatusLogger);

            OrderAggregate aggregate = new OrderAggregate();
            aggregate.OrderDate = DateTime.Now;
            aggregate.ShipAddress = order.ShipAddress;
            aggregate.ShipCity = order.ShipCity;
            aggregate.ShipCountry = order.ShipCountry;
            aggregate.ShipPostalCode = order.ShipPostalCode;
            aggregate.CustomerId = order.CustomerId;
            foreach (CreateOrderDetailDto item in order.OrderDetails)
            {
                aggregate.AddDetail(item.ProdcutId, item.UnitPrice, item.Quantity);
            }
            //registrar en la base de datos
            OrderRepository.CreateOrder(aggregate);
            LogRepository.Add(new Main.Entities.Log($"Crear orden de compra"));
            await UnitOfwork.SaveChanges();         //guarda los dos registros

            if (aggregate.OrderDetails.Count > 3)
            {
                SpecialOrderCreatedEvent specialOrder =
                    new SpecialOrderCreatedEvent(aggregate.Id, aggregate.OrderDetails.Count);
                await Events.Raise(specialOrder);
            }

            await Output.Handle(aggregate.Id);
        }
    }
}
