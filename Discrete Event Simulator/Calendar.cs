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

        public Calendar()
        {
            EventList = new List<Event>();    
        }

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
            EventList.Sort( (e1,e2) => e1.EventTime.CompareTo(e2.EventTime) );
        }

        public Event GetNextEvent()
        {
            Event e = EventList[0];
            RemoveEvent(e);
            return e;
        }
    }
}
