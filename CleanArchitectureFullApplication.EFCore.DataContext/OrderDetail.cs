using CleanArchitectureFullApplication.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.EFCore.DataContext
{
    public class OrderDetail : Sales.Entities.ValueObjects.OrderDetail
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
