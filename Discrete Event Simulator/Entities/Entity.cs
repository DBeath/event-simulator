namespace Discrete_Event_Simulator.Entities
{
    public class Entity
    {
        public string ProductType { get; set; }
        public int EntityId { get; set; }

        public int StartTimeQueue { get; set; }
        public int ExitTimeQueue { get; set; }
        public int StartTimeSystem { get; set; }
        public int ExitTimeSystem { get; set; }

        public Entity(string productType, int id, int startTime)
        {
            ProductType = productType;
            EntityId = id;
            StartTimeSystem = startTime;
        }
    }
}
