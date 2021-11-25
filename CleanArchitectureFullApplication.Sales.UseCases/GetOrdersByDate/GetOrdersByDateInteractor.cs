using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.Main.Interfaces;
using CleanArchitectureFullApplication.Main.Validators;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces;
using CleanArchitectureFullApplication.Sales.UseCases.Common.Specifications;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.Common;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.GetOrdersByDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.GetOrdersByDate
{
    public class GetOrdersByDateInteractor : IGetOrdersByDateInputPort
    {
        readonly IOrderReadableRepository OrderRepository;
        readonly ILogWritableRepository LogRepository;
        readonly IUnitOfWork UnitOfwork;
        readonly IGetOrdersOutputPort Output;
        readonly IEnumerable<IValidator<GetOrdersByDateDto>> Validators;
        readonly IValidatorService<GetOrdersByDateDto> Validator;

        public GetOrdersByDateInteractor(
            IOrderReadableRepository orderRepository, 
            ILogWritableRepository logRepository, 
            IUnitOfWork unitOfwork, IGetOrdersOutputPort output, 
            IEnumerable<IValidator<GetOrdersByDateDto>> validators, 
            IValidatorService<GetOrdersByDateDto> validator)
        {
            OrderRepository = orderRepository;
            LogRepository = logRepository;
            UnitOfwork = unitOfwork;
            Output = output;
            Validators = validators;
            Validator = validator;
        }

        public async ValueTask Handle(GetOrdersByDateDto dto)
        {
            Validator.Validate(dto, Validators, null);
            IEnumerable<OrderDto> orders = OrderRepository.GetOrdersWithDetailBySpecification(
                new OrderDateSpecification(dto.OrderDate));
            LogRepository.Add($"Obtener listado de ordenes de compra a fecha {dto.OrderDate}");
            await UnitOfwork.SaveChanges();
            await Output.Handle(orders);
        }
    }
}
