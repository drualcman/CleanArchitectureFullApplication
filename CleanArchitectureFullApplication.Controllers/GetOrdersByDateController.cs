using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.Presenters;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.Common;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.GetOrdersByDate;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Controllers
{
    public class GetOrdersByDateController : IGetOrdersByDateController
    {
        readonly IGetOrdersByDateInputPort Input;
        readonly IGetOrdersOutputPort Output;

        public GetOrdersByDateController(IGetOrdersByDateInputPort input, IGetOrdersOutputPort output)
        {
            Input = input;
            Output = output;
        }

        public async Task<OrdersViewModel> GetOrderByDate(GetOrdersByDateDto date)
        {
            await Input.Handle(date);
            return ((IPresenter<OrdersViewModel>)Output).Content;
        }
    }
}
