using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Events
{
    /// <summary>
    /// Con esta interfaz manejamos el evento
    /// </summary>
    /// <typeparam name="EventType"></typeparam>
    public interface IEventHandler<EventType> where EventType : IEvent
    {
        ValueTask Handle(EventType eventTypeInstance);
    }
}
