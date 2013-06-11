namespace Discrete_Event_Simulator.Entities
{
    public class Entity
    {
        public string ProductType { get; set; }
        public int EntityId { get; set; }

        public double StartTimeQueue { get; set; }
        public double ExitTimeQueue { get; set; }
        public double StartTimeSystem { get; set; }
        public double ExitTimeSystem { get; set; }

        public Entity(string productType, int id, double startTime)
        {
            ProductType = productType;
            EntityId = id;
            StartTimeSystem = startTime;
        }
    }
}
