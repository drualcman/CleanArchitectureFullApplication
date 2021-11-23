using System;

namespace CleanArchitectureFullApplication.ViewModels
{
    /// <summary>
    /// Esto es el DTO de lo que se va a devolver
    /// </summary>
    public class CreateOrderViewModel
    {
        public int OrderId { get; set; }
        public CreateOrderViewModel(int orderId) => 
            OrderId = orderId;
    }
}
