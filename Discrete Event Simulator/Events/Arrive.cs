using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class Arrive : Event
    {
        public Arrive(int time, Entity entity, Simulation sim) : base(time, entity, sim)
        {
            EventEntity = entity;
            EventTime = time;
            EventSimulation = sim;
        }

        // The arrival event of an entity. It will start waiting to join a queue.
        public override void ProcessEvent()
        {
            RemoveSelfFromCalendar();
            // If the queues are not full, then start waiting. Otherwise nothing more will happen to the entity.
            if (EventSimulation.CurrentInQueue < EventSimulation.SimConstants.MaxOnHold)
            {
                EventSimulation.EventFactory.CreateJoinQueue(EventEntity);
            }
            else
            {
                EventSimulation.Stats.IncreaseBusyCount();
            }
        }

        public override string ToString()
        {
            return "Arrive";
        }
    }
}
