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
        public Dictionary<string, int> ProductType { get; set; }

        public int[] ProductTypePercent { get; set; } 

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

        //-------------------------------------------------------------------------------
        // Random Value Multipliers
        //-------------------------------------------------------------------------------

        // The multiplier for calculating the interval between the arrivals of entities.
        public const double EntityArriveMultiplier = 0.33;

        // The multiplier for calculating the time it takes for a car stereo call
        // to be serviced.
        public const double CarStereoServiceMultiplier = 2;

        public SimulationConstants()
        {
            ProductType = new Dictionary<string, int> { { "None", 0 } };
            ProductTypePercent = new[] { 50, 50 };
            ProductType.Add("Car Stereo", 50);
            ProductType.Add("Other", 50);
        }
    }
}
