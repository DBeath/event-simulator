using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator
{
    public class Simulation
    {
        public Calendar EventCalendar;
        public QueueManager QueueManager;
        public List<Entity> EntityList;
        public Dictionary<int, Queue> QueueDict;
        public EventFactory EventFactory;
        public EntityFactory EntityFactory;

        public double CurrentTime;

        public Simulation()
        {
            
        }

        public void RunAllEvents()
        {
            
        }

    }
}
