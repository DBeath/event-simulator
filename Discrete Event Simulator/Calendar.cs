using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator
{
    public class Calendar
    {
        public List<Event> EventList;

        public void AddEvent(Event e)
        {
            EventList.Add(e);
        }

        public void RemoveEvent(Event e)
        {
            if (EventList.Contains(e))
            {
                EventList.Remove(e);
            }
        }

        public void SortEvents()
        {
            EventList.Sort();
        }

        public Event GetNextEvent()
        {
            Event e = EventList[0];
            RemoveEvent(e);
            return e;
        }
    }
}
