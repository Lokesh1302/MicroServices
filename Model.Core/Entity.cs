using OrderSystem.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem.Model.Core
{
    public abstract class Entity
    {
        private List<IEvents> events = new List<IEvents>();

        public abstract void Validate();
        public abstract void When(IEvents @event);


        public void AddEvents(IEvents @event)
        {
            events.Add(@event);
        }

        public IEnumerable<IEvents> GetEvents()
        {
            return events.AsEnumerable();
        }

        public void ClearEvents()
        {
            events.Clear();
        }

        public void Apply(IEvents @event)
        {
            When(@event);
            Validate();
            AddEvents(@event);
        }
    }
}
