using System;
using System.Collections;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public abstract class Event : IComparable
    {
        // Comparison helper class.
        private class SortTimeAscendingHelper : IComparer
        {
            public int Compare(object x, object y)
            {
                Event e1 = (Event) x;
                Event e2 = (Event) y;

                if (e1.EventTime > e2.EventTime)
                    return 1;

                if (e1.EventTime < e2.EventTime)
                    return -1;

                else
                    return 0;
            }
        }

        public double EventTime;
        public Entity EventEntity;
        public Simulation EventSimulation;

        // Constructor
        protected Event()
        {

        }

        public abstract void ProcessEvent();

        public void RemoveSelfFromCalendar()
        {
            EventSimulation.EventCalendar.RemoveEvent(this);
        }

        // Default comparator
        public int CompareTo(object obj)
        {
            IComparer sortTimeAscending = SortTimeAscending();
            return sortTimeAscending.Compare(this, obj);
        }

        // Comparer
        public static IComparer SortTimeAscending()
        {
            return new SortTimeAscendingHelper();
        }
    }
}
