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
            List<Entity> entityList = new List<Entity>();
            entityList.Add(new Entity());
            // Entity number starts at 2, 1 being the EndReplication Entity.
            for (int i = 2; i < numEntities + 2; i++)
            {
                entityList.Add(new Entity());
            }
        }
    }
}
