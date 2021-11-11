using CleanArchitectureFullApplication.Sales.Entities.Enums;
using System;

namespace CleanArchitectureFullApplication.Sales.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DiscountTypes DiscountType { get; set; } = DiscountTypes.Percentage;
        public double Discount { get; set; } = 10;
        public ShippingTypes ShippingType { get; set; } = ShippingTypes.Road;
    }
}
