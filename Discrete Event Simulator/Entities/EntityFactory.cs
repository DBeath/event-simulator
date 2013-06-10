using System.Collections.Generic;

namespace Discrete_Event_Simulator.Entities
{
    public class EntityFactory
    {
        public RandomValue rGen;

        public EntityFactory(RandomValue startRGen)
        {
            rGen = startRGen;
        }

        public List<Entity> CreateEntities(int numEntities)
        {
            List<Entity> entityList = new List<Entity>
                {
                    // The End Replication Entity.
                    new Entity(Constants.ProductType.None, 1, Constants.SimulationEndTime)
                };


            double entityStartTime = Constants.SimulationStartTime;
            // Entity number starts at 2, 1 being the End Replication Entity.
            for (int i = 2; i < numEntities + 2; i++)
            {
                entityStartTime += rGen.Roll(Constants.EntityArriveMultiplier);
                entityList.Add(new Entity());
            }
        }
    }
}
