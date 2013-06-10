using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Queues
{
    public class Server
    {
        public Constants.ProductType ProductType;
        public Entity CurrentEntity;
        public bool Available;

        public Server(Constants.ProductType productType)
        {
            ProductType = productType;
            Available = true;
        }

        // Remove the current Entity from the Server
        public void RemoveCurrentEntity()
        {
            Available = true;
        }
       
        // Add an Entity to the Server
        public void AddEntity(Entity newEntity)
        {
            CurrentEntity = newEntity;
        }
    }
}
