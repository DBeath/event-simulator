using System.Collections.Generic;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator.Queues
{
    public class EntityQueue
    {
        public string ProductType { get; set; }
        public Queue<Entity> ThisEntityQueue { get; set; }
        public List<Server> ServerList { get; set; }
        public EventFactory EventFactory { get; set; }
        public double CompleteServiceMultiplier { get; set; }

        // Constructor
        public EntityQueue(string startProductType, EventFactory startEventFactory, double startCSMultiplier, int startNumServers)
        {
            ProductType = startProductType;
            EventFactory = startEventFactory;
            CompleteServiceMultiplier = startCSMultiplier;
            ServerList = new List<Server>();
            ThisEntityQueue = new Queue<Entity>();

            // Create the servers.
            for (int i = 0; i < startNumServers; i++ )
            {
                ServerList.Add(new Server(ProductType));
            }

        }

        // Complete the service of an Entity, removing the entity from the appropriate Server.
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

        // Add an entity to the queue.
        public void AddEntity(Entity entity)
        {
            ThisEntityQueue.Enqueue(entity);
            UpdateQueue();
        }

        // Update the queue, removing an entity from the queue to be serviced
        // if a Server is available.
        public void UpdateQueue()
        {
            foreach (Server server in ServerList)
            {
                if (server.Available && ThisEntityQueue.Count > 0)
                {
                    Entity newEntity = ThisEntityQueue.Dequeue();
                    server.AddEntity(newEntity);
                    EventFactory.CreateCompleteService(newEntity, CompleteServiceMultiplier);
                }
            }
        }

        // Return the number of entities in the queue.
        public int GetNumInQueue()
        {
            return ThisEntityQueue.Count;
        }
    }
}
