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

        // Add an event to the Calendar
        public void AddEvent(Event e)
        {
            EventList.Add(e);
        }

        // Remove an event from the Calendar
        public void RemoveEvent(Event e)
        {
            if (EventList.Contains(e))
            {
                EventList.Remove(e);
            }
        }

        // Sort the events in the Calendar by time
        public void SortEvents()
        {
            EventList.Sort( (e1,e2) => e1.EventTime.CompareTo(e2.EventTime) );
        }

        // Get the next event from the Calendar
        public Event GetNextEvent()
        {
            Event e = EventList[0];
            RemoveEvent(e);
            return e;
        }

        // Remove all events from the list
        public void RemoveAllEvents()
        {
            //for (int i = 0; i < EventList.Count; i++ )
            //{
            //    EventList.RemoveAll();
            //}
            EventList.Clear();
        }
    }
}
