using System;
using System.Collections.Generic;

namespace Discrete_Event_Simulator.Entities
{
    public class EntityFactory
    {
        private RandomValue rGen;
        private Random productTypeRoll;
        private SimulationConstants simConstants;

        public EntityFactory(RandomValue startRGen)
        {
            rGen = startRGen;
            productTypeRoll = new Random();
        }

        // Creates and returns a list of entities.
        public List<Entity> CreateEntities(SimulationConstants startSimConstants)
        {
            // Assign the constants for this simulation.
            simConstants = startSimConstants;

            // Create a list with the End Replication Entity.
            List<Entity> entityList = new List<Entity>
                {
                    // The End Replication Entity.
                    new Entity("None", 1, simConstants.SimulationEndTime)
                };

            // The base entity start time is the start time of the simulation.
            int entityStartTime = simConstants.SimulationStartTime;
            // Entity id starts at 2, 1 being the End Replication Entity.
            for (int i = 2; i < simConstants.NumEntities + 2; i++)
            {
                // Roll the value for the start time of the new entity.
                entityStartTime += rGen.Roll(SimulationConstants.EntityArriveMultiplier);
                // Create a new entity and add it to the entity list.
                entityList.Add(new Entity(CalcProductType(), i, entityStartTime));
            }

            return entityList;
        }

        // Randomly assigns a Product Type to each entity bases on the percentage chance of that Product.
        public string CalcProductType()
        {
            // Roll a random percentage value.
            int percent = productTypeRoll.Next(1, 101);
            // The starting percentage value.
            int prevpercent = 0;

            // Loop through the ProductType dictionary to find the corresponding product.
            //
            // eg. If Product1 = 25% and Product2 = 75%, then a roll between 1 and 25 will assign Product1,
            // while a roll between 26 and 100 will assign Product2.
            string productType = null;
            foreach (KeyValuePair<string, int[]> product in simConstants.ProductType)
            {
                if (percent <= (product.Value[0] + prevpercent) && percent > prevpercent)
                {
                    productType = product.Key;
                }
                prevpercent = product.Value[0];
            }

            return productType;
        }
    }
}
