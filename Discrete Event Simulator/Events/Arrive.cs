using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class Arrive : Event
    {
        public Arrive(double time, Entity entity, Simulation sim) : base(time, entity, sim)
        {
        }

        public override void ProcessEvent()
        {
            throw new NotImplementedException();
        }
    }
}
