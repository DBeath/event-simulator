using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discrete_Event_Simulator
{
    public class Variables
    {
        public enum CallTypes 
        {
            CarStereo = 1, 
            Other 
        };

        public enum EventTypes
        {
            CallArrive=1,
            CompleteIVR,
            CompleteServiceCarStereo,
            CompleteServiceOther,
        };
    }
}
