using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;
using Discrete_Event_Simulator.Queues;

namespace Discrete_Event_Simulator
{
    public class Simulation
    {
        public Calendar EventCalendar;
        public QueueManager QueueManager;
        public List<Entity> EntityList;
        public Dictionary<int, EntityQueue> QueueDict;
        public EventFactory EventFactory;
        public EntityFactory EntityFactory;
        public SimulationConstants SimulationConstants;

        public double CurrentTime;

        public Simulation()
        {
            EventCalendar = new Calendar();
        }

        public void RunAllEvents()
        {
            
        }

    }
}
