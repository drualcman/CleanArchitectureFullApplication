using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Events
{
    public interface IEventHub<EventType> where EventType : IEvent
    {
        ValueTask Raise(EventType eventTypeInstance);
    }
}
