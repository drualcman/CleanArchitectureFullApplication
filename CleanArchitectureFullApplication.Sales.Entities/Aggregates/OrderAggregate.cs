using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.Entities.Aggregates
{
    /// <summary>
    /// Como implementar agregado.
    /// Una ordern debe de tener detalles
    /// </summary>
    public class OrderAggregate : Order
    {
        //almacenar los detalles de la orden de forma privada
        readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();

        //exponer la lista pero como solo lectura para que no pueda ser modificada
        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        //exponer un metodo para agregar elementos
        public void AddDetail(OrderDetail detail)
        {
            // controlar las reglas de negocio aqui como que no puede tener mas de 3 productos
            // o que no haya productos duplicados haciendo una suma de todo

            //controlar que no haya repetidos
            OrderDetail existingDetail = OrderDetailsField
                .FirstOrDefault(p => p.ProductId == detail.ProductId);

            if (existingDetail != null) existingDetail.Quantity += detail.Quantity;
            else OrderDetailsField.Add(detail);
           
            OrderDetailsField.Add(detail);
        }

        public void AddDetail(int productId, decimal unitPrice, short quatity) =>
            AddDetail(new OrderDetail
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quatity
            });


        /// <summary>
        /// Agregar todas las funciones que se necesiten para manejar el objeto
        /// </summary>
        /// <param name="productId"></param>
        public void RemoveDetail(int productId)
        {
            OrderDetail existingDetail = OrderDetailsField
                .FirstOrDefault(p => p.ProductId == productId);
            OrderDetailsField.Remove(existingDetail);
        }
    }
}
