using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discrete_Event_Simulator
{
    // Constants for each Simulation.
    public class SimulationConstants
    {   
        // The dictionary which has the values for each Product Type.
        // The key is the name of the product.
        // Array index 0 = Product Type percentage chance
        // Array index 1 = Service time multiplier
        // Array index 2 = Number of servers
        public Dictionary<string, int[]> ProductType { get; set; }

        // Each type of Event that can occur.
        public enum EventType
        {
            Arrive = 1, // CallArrive
            JoinQueue, // CompleteIVR
            CompleteService, // CompleteService (CarStereo and Other)
        };

        // The start and end times of the Simulation in seconds.
        public int SimulationStartTime = 0;
        public int SimulationEndTime = 10800;

        // The time the thread should sleep for.
        public int SleepTime = 0;

        // The number of Entities to create.
        public int NumEntities = 50;

        // Maximum number of entities in queues.
        public int MaxOnHold = 10;

        //-------------------------------------------------------------------------------
        // Random Value Multipliers
        //-------------------------------------------------------------------------------

        // The multiplier for calculating the interval between the arrivals of entities.
        public const double EntityArriveMultiplier = 0.33;

        // The multiplier for the time it takes an entity to join a queue after it arrives.
        public double JoinQueueMultiplier = 2; 

        // Constructor
        public SimulationConstants()
        {
            
            ProductType = new Dictionary<string, int[]>();

            ProductType.Add("Car Stereo", new[]{ 50, 2, 2 });
            ProductType.Add("Other", new[]{ 50, 2, 2 });
        }

    }
}
