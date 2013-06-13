using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class BeginService : Event
    {
        public BeginService(double time, Entity entity, Simulation sim) : base(time, entity, sim)
        {
            EventEntity = entity;
            EventTime = time;
            EventSimulation = sim;
        }

        public override void ProcessEvent()
        {
           
        }
    }
}
