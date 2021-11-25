using CleanArchitectureFullApplication.Dto.Common;
using CleanArchitectureFullApplication.Main.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.Common.Specifications
{
    public class OrderDateSpecification: Specification<OrderDto>
    {
        readonly DateTime OrderDate;

        public OrderDateSpecification(DateTime orderDate)
        {
            OrderDate = orderDate;
        }

        public override Expression<Func<OrderDto, bool>> ConditionExpression => 
            o => o.OrderDate.Date == OrderDate.Date;
    }
}
