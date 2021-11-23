using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.Presenters;
using CleanArchitectureFullApplication.Sales.UseCases.Ports.CreateOrder;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;

        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outputPort)
        {
            InputPort = inputPort;
            OutputPort = outputPort;
        }

        public async ValueTask<CreateOrderViewModel> CreateOrder(CreateOrderDto order)
        {
            await InputPort.Handle(order);
            return ((IPresenter<CreateOrderViewModel>)OutputPort).Content;
        }
    }
}
