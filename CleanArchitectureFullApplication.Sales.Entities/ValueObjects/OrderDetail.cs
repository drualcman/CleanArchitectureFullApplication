using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.Entities.ValueObjects
{
    /// <summary>
    /// cambiar los detalles como objeto de valor valueobject.
    /// no necesita el orderId ya que como esta en el agregado lo cogera de la orden
    /// </summary>
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
