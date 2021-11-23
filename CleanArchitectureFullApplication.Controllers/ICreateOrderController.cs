using CleanArchitectureFullApplication.Dto.CreateOrder;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Controllers
{
    public interface ICreateOrderController
    {
        ValueTask<CreateOrderViewModel> CreateOrder(CreateOrderDto order);
    }
}
