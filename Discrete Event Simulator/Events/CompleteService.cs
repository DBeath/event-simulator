using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class CompleteService : Event
    {
        public CompleteService(int time, Entity entity, Simulation sim) : base(time, entity, sim)
        {
            EventEntity = entity;
            EventTime = time;
            EventSimulation = sim;
        }

        // Complete the service of an entity by removing it from the calendar.
        // Nothing more should happen to the entity.
        public override void ProcessEvent()
        {
            RemoveSelfFromCalendar();
            // Set the entity exit system time to the current time.
            EventSimulation.CompleteService(EventEntity);
            EventEntity.ExitTimeSystem = EventSimulation.CurrentTime;
            
        }

        public override string ToString()
        {
            return "Complete Service " + EventEntity.ProductType;
        }
    }
}
