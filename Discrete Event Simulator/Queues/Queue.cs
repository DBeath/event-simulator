using System.Collections.Generic;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator.Queues
{
    public class Queue
    {
        public Constants.ProductType ProductType;
        public Queue<Entity> EntityQueue;
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
            EntityQueue.Enqueue(entity);
            UpdateQueue();
        }

        public void UpdateQueue()
        {
            foreach (Server server in ServerList)
            {
                if (server.Available && EntityQueue.Count > 0)
                {
                    Entity newEntity = EntityQueue.Dequeue();
                    server.AddEntity(newEntity);
                    EventFactory.CreateEvent(Constants.EventType.CompleteService, newEntity);
                }
            }
        }
    }
}
