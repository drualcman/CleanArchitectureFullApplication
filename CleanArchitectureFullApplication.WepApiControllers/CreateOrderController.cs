using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WepApiControllers
{
    [Route("api/order")]
    [ApiController]
    public class CreateOrderController : ControllerBase
    {
        readonly ICreateOrderController Controller;

        public CreateOrderController(ICreateOrderController controller)
        {
            Controller = controller;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto order)
        {
            CreateOrderViewModel view = await Controller.CreateOrder(order);
            return Ok(view.OrderId);
        }
    }
}
