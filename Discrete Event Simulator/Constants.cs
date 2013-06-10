using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discrete_Event_Simulator
{
    // Constants for each Simulation.
    public static class Constants
    {
        // Each Product that there is a Queue for.
        public enum ProductType 
        {
            None = 0,
            CarStereo = 1, 
            Other,
        };

        public static int[] ProductTypePercent = new[]{0, 50, 50};

        // Each type of Event that can occur.
        public enum EventType
        {
            Arrive = 1, // CallArrive
            JoinQueue, // CompleteIVR
            CompleteService, // CompleteService (CarStereo and Other)
        };

        // The start and end times of the Simulation in seconds.
        public const double SimulationStartTime = 0;
        public const double SimulationEndTime = 10800;

        //-------------------------------------------------------------------------------
        // Random Value Multipliers
        //-------------------------------------------------------------------------------

        // The multiplier for calculating the interval between the arrivals of entities.
        public const double EntityArriveMultiplier = 0.33;

        // The multiplier for calculating the time it takes for a car stereo call
        // to be serviced.
        public const double CarStereoServiceMultiplier = 2;
    }
}
