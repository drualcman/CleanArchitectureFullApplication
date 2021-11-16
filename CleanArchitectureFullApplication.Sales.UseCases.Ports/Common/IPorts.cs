using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Sales.UseCases.Ports.Common
{
    public interface IPort
    {
        ValueTask Handle();
    }

    public interface IPort<T>
    {
        ValueTask Handle(T dto);
    }
}
