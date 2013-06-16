using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class JoinQueue : Event
    {
        public JoinQueue(int time, Entity entity, Simulation sim) : base(time, entity, sim)
        {
            EventEntity = entity;
            EventTime = time;
            EventSimulation = sim;
        }

        // Add the entity to the queue.
        public override void ProcessEvent()
        {
            RemoveSelfFromCalendar();
            // Set the entity queue start time for the entity to the current time.
            EventEntity.StartTimeQueue = EventSimulation.CurrentTime;
            // Add the entity to the queue.
            EventSimulation.AddEntityToQueue(EventEntity);
        }

        public override string ToString()
        {
            return "Join Queue " + EventEntity.ProductType;
        }
    }
}
