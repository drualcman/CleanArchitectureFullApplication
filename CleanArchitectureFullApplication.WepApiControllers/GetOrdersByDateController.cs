using CleanArchitectureFullApplication.Controllers;
using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.WepApiControllers
{

    [Route("api/order")]
    [ApiController]
    public class GetOrdersByDateController : ControllerBase
    {
        readonly IGetOrdersByDateController Controller;

        public GetOrdersByDateController(IGetOrdersByDateController controller)
        {
            Controller = controller;
        }

        [HttpGet("get-orders-by-date")]
        public async Task<IActionResult> GetOrdersByDate(DateTime date)
        {
            OrdersViewModel view = await Controller.GetOrderByDate( new GetOrdersByDateDto { OrderDate = date });
            return Ok(view.Orders);
        }

        [HttpGet("get-orders-by-date/{date}")]
        public async Task<IActionResult> GetOrdersByDate(GetOrdersByDateDto date)
        {
            OrdersViewModel view = await Controller.GetOrderByDate(date);
            return Ok(view.Orders);
        }
    }
}
