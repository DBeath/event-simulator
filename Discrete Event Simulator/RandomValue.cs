using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Discrete_Event_Simulator
{
    public class RandomValue
    {
        private static Random rGen;

        public RandomValue()
        {
            rGen = new Random();
        }

        // Returns a time in seconds based on the roll of two dice modified by the multiplier.
        public int Roll(double multiplier)
        {
            int d1 = rGen.Next(1, 7);
            int d2 = rGen.Next(1, 7);
            return Convert.ToInt32(((d1 + d2)*multiplier) * 60);
        }
    }
}
