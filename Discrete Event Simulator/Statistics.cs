using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discrete_Event_Simulator.Queues;

namespace Discrete_Event_Simulator
{
    public class Statistics
    {

        public int BusySignalCount;
        public double AverageWaitingTime;
        // Dictionary to hold stats on each queue;
        // Array index 0 = Completions Count
        // Array index 1 = Excessive Wait Count
        // Array index 2 = Representative Utilization
        // Array index 3 = Average number waiting
        public Dictionary<string, double[]> StatsDict;
        // Holds the number of entities waiting in each queue at each event.
        public Dictionary<string, List<int>> WaitDict; 

        private Simulation sim;

        
        
        // Constructor
        public Statistics(Simulation sim)
        {
            sim = sim;

            // Create the stats dictionary.
            StatsDict = new Dictionary<string, double[]>();
            WaitDict = new Dictionary<string, List<int>>();
            foreach (KeyValuePair<string, EntityQueue> valuePair in sim.QueueDict)
            {
                if (StatsDict.ContainsKey(valuePair.Key))
                {
                    StatsDict.Remove(valuePair.Key);
                }
                StatsDict.Add(valuePair.Key, new double[4]);
                WaitDict.Add(valuePair.Key, new List<int>());
            }
        }

        // Records all the calls that were dropped.
        public void IncreaseBusyCount()
        {
            BusySignalCount += 1;
        }

        // Records the number of completed calls for each product type.
        public void IncreaseCompletion(string productType)
        {
            StatsDict[productType][0] += 1;
        }

        // Updates the average number of entities waiting in the queue.
        public void UpdateAverageWait(int inqueue, string productType)
        {
            WaitDict[productType].Add(inqueue);
            StatsDict[productType][3] = ComputeAverageWaiting(productType);

        }

        // Compute the average length of the queue for each product type
        public double ComputeAverageWaiting(string productType)
        {
            List<int> waitList = WaitDict[productType];
            int total = waitList.Sum();
            return Convert.ToDouble(total/waitList.Count);
        }
    }
}
