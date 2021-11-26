using CleanArchitectureFullApplication.Dto.GetOrdersByDate;
using CleanArchitectureFullApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Controllers
{
    public interface IGetOrdersByDateController
    {
        Task<OrdersViewModel> GetOrderByDate(GetOrdersByDateDto date);
    }
}
