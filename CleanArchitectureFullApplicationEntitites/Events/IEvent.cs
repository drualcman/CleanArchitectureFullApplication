using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Events
{
    /// <summary>
    /// Usar esta interfaz como bandera para identificar que la clase es un evento
    /// luego debe de haber un manejador de evento con los metodos o propiedades
    /// </summary>
    public interface IEvent
    {
    }
}
