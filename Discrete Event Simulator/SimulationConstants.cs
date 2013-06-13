using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discrete_Event_Simulator
{
    // Constants for each Simulation.
    public class SimulationConstants
    {
        // Each Product that there is a Queue for.
        //public enum ProductType
        //{
        //    None = 0,
        //    CarStereo = 1,
        //    Other,
        //};
        
        // The dictionary which has the values for each Product Type.
        // The key is the name of the product.
        // The value must be an integer array of size 3, with the zero index being the percentage chance 
        // that an entity of that type will be created, the one index being the multiplier
        // for the service time of that product, and the two index being the number of 
        // servers that the queue has.
        public Dictionary<string, int[]> ProductType { get; set; }

        // Each type of Event that can occur.
        public enum EventType
        {
            Arrive = 1, // CallArrive
            JoinQueue, // CompleteIVR
            CompleteService, // CompleteService (CarStereo and Other)
        };

        // The start and end times of the Simulation in seconds.
        public double SimulationStartTime = 0;
        public double SimulationEndTime = 10800;

        // The number of Entities to create.
        public int NumEntities = 10;

        // Maximum number of entities in queues.
        public int MaxOnHold = 10;

        //-------------------------------------------------------------------------------
        // Random Value Multipliers
        //-------------------------------------------------------------------------------

        // The multiplier for calculating the interval between the arrivals of entities.
        public const double EntityArriveMultiplier = 0.33;

        // The multiplier for the time it takes an entity to join a queue after it arrives.
        public double JoinQueueMultiplier = 2; 

        // The multipliers for the time it takes to finish service in each queue.
        public double[] ServiceMultiplier = new double[]{ 2, 2};


        // Constructor
        public SimulationConstants()
        {
            
            ProductType = new Dictionary<string, int[]> { { "None", new[]{0,0,0} } };

            ProductType.Add("Car Stereo", new[]{ 50, 2, 2 });
            ProductType.Add("Other", new[]{ 50, 2, 2 });
        }

    }
}
