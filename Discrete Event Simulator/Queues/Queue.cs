using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator
{
    public class Queue
    {
        public int ProductType;
        public Stack<Entity> EntityQueue;
        public List<Server> ServerList;
        public EventFactory EventFactory;

        public void CompleteService(Entity entity)
        {
            
        }

        public void AddEntity(Entity entity)
        {
            
        }

        public void UpdateQueue()
        {
            
        }
    }
}
