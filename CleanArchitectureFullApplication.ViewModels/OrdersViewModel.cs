using CleanArchitectureFullApplication.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.ViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<OrderDto> Orders { get; }

        public OrdersViewModel(IEnumerable<OrderDto> orders)
        {
            Orders = orders;
        }
    }
}
