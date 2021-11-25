using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.Ports.Common
{
    public interface IGetOrdersOutputPort : IPort<IEnumerable<OrderDto>> 
    {
    }
}
