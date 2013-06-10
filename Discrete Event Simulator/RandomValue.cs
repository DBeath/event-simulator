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

        public double Roll(double multiplier)
        {
            int d1 = rGen.Next(1, 7);
            int d2 = rGen.Next(1, 7);
            return (d1 + d2)*multiplier;
        }
    }
}
