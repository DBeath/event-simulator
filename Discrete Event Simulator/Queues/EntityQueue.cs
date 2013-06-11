using System.Collections.Generic;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator.Queues
{
    public class EntityQueue
    {
        public string ProductType;
        public Queue<Entity> ThisEntityQueue;
        public List<Server> ServerList;
        public EventFactory EventFactory;

        public void CompleteService(Entity entity)
        {
            foreach (Server server in ServerList)
            {
                if (server.CurrentEntity == entity)
                {
                    server.RemoveCurrentEntity();
                }
            }
            UpdateQueue();
        }

        public void AddEntity(Entity entity)
        {
            ThisEntityQueue.Enqueue(entity);
            UpdateQueue();
        }

        public void UpdateQueue()
        {
            foreach (Server server in ServerList)
            {
                if (server.Available && ThisEntityQueue.Count > 0)
                {
                    Entity newEntity = ThisEntityQueue.Dequeue();
                    server.AddEntity(newEntity);
                    EventFactory.CreateEvent(SimulationConstants.EventType.CompleteService, newEntity);
                }
            }
        }
    }
}
