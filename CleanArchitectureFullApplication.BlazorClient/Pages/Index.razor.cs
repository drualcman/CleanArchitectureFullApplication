using CleanArchitectureFullApplication.BlazorClient.Exceptions;
using CleanArchitectureFullApplication.BlazorClient.Services;
using CleanArchitectureFullApplication.Dto.CreateOrder;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.BlazorClient.Pages
{
    public partial class Index
    {
        [Inject]
        public CleanArchitectureApiClient Service { get; set; }

        CreateOrderDto Order = new CreateOrderDto
        {
            OrderDetails = new List<CreateOrderDetailDto>()
        };

        string Message;
        HttpCustomException Error;

        void AddProduct()
        {
            Order.OrderDetails.Add(new CreateOrderDetailDto());            
        }

        async Task Send()
        {
            try
            {
                int orderId = await Service.CreateOrder(Order);
                Message = $"Order {Order} creada";
                Error = null;
            }
            catch (HttpCustomException ex)
            {
                Message = ex.Message;
                Error = ex;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                Error = null;
            }
        }
    }
}
