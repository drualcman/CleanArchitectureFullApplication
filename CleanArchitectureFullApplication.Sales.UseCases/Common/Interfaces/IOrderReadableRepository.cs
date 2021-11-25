using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.Main.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.Common.Interfaces
{
    public interface IOrderReadableRepository
    {
        IEnumerable<OrderDto> GetOrdersWithDetailBySpecification(
            Specification<OrderDto> specification);
    }
}
