using System;
using System.Collections;

namespace Discrete_Event_Simulator.Events
{
    public class Event : IComparable
    {
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

        public int EventTime;

        public Event()
        {
            Random rGen = new Random();
            EventTime = rGen.Next();
        }

        public int CompareTo(object obj)
        {
            IComparer sortTimeAscending = SortTimeAscending();
            return sortTimeAscending.Compare(this, obj);
        }

        public static IComparer SortTimeAscending()
        {
            return new SortTimeAscendingHelper();
        }
    }
}
