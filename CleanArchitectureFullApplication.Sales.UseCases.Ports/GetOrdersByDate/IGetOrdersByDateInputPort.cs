using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.Ports.GetOrdersByDate
{
    public interface IGetOrdersByDateInputPort: IPort<GetOrdersByDateDto>
    {
    }
}
