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

        // Each type of Event that can occur.
        public enum EventType
        {
            Arrive = 1, // CallArrive
            JoinQueue, // CompleteIVR
            CompleteService, // CompleteService (CarStereo and Other)
        };

        public 
    }
}
