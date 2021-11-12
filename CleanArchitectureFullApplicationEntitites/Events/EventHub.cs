using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureFullApplication.Main.Events
{
    public class EventHub<EventType> : IEventHub<EventType> where EventType : IEvent
    {
        readonly IEnumerable<IEventHandler<EventType>> EventHandlers;

        public EventHub(IEnumerable<IEventHandler<EventType>> eventHandlers) =>
            EventHandlers = eventHandlers;

        public async ValueTask Raise(EventType eventTypeInstance)
        {
            foreach (IEventHandler<EventType> handler in EventHandlers)
            {
                await handler.Handle(eventTypeInstance);
            }
        }
    }
}
