using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Queues
{
    public class Server
    {
        public string ProductType;
        public Entity CurrentEntity;
        public bool Available;

        // Constructor
        public Server(string productType)
        {
            ProductType = productType;
            Available = true;
        }

        // Remove the current Entity from the Server
        public void RemoveCurrentEntity()
        {
            Available = true;
            CurrentEntity = null;
        }
       
        // Add an Entity to the Server
        public void AddEntity(Entity newEntity)
        {
            CurrentEntity = newEntity;
        }
    }
}
