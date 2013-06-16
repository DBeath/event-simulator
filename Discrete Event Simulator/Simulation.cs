using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;
using Discrete_Event_Simulator.Queues;

namespace Discrete_Event_Simulator
{
    public class Simulation
    {
        public Calendar EventCalendar;
        public List<Entity> EntityList;
        public Dictionary<string, EntityQueue> QueueDict;
        public EventFactory EventFactory;
        public EntityFactory EntityFactory;
        public SimulationConstants SimConstants;
        public Display SimDisplay;
        public Statistics Stats;

        public int CurrentInQueue { get; set; }
        public int CurrentTime;

        // Constructor
        public Simulation()
        {
            EventCalendar = new Calendar();
            QueueDict = new Dictionary<string, EntityQueue>();
            EntityList = new List<Entity>();
        }

        // Intitialise all the parameters for the current simulation.
        public void IntitialiseSimulation(SimulationConstants startSimConstants)
        {
            
            SimConstants = startSimConstants;
            SimDisplay.CreateColumns();
            SimDisplay.ClearDataGridView();

            // Create the queues.
            foreach (KeyValuePair<string, int[]> productType in SimConstants.ProductType)
            {
                if (QueueDict.ContainsKey(productType.Key))
                {
                    QueueDict.Remove(productType.Key);
                }
                QueueDict.Add(productType.Key, new EntityQueue(productType.Key, EventFactory, productType.Value[1], productType.Value[2]));
            }

            // Intitialise the statistics for this simulation.
            Stats = new Statistics(this);

            //Create the entities.
            EntityList = EntityFactory.CreateEntities(SimConstants);

            // Get the End Replication Entity and create the End Replication Event.
            int index = EntityList.FindIndex(e => e.EntityId == 1);
            EventFactory.CreateEndReplication(EntityList.ElementAt(index));
            EntityList.RemoveAt(index);
            

            // Create the arrive events.
            foreach (Entity entity in EntityList)
            {
                EventFactory.CreateArrive(entity);
            }

            CurrentInQueue = 0;
            CurrentTime = SimConstants.SimulationStartTime;

            
        }

        // Run the simulation.
        public void RunAllEvents()
        {
            EventCalendar.SortEvents();
            while (EventCalendar.EventList.Count != 0)
            {
                RunNextEvent();
                System.Threading.Thread.Sleep(SimConstants.SleepTime);
            }
        }

        // Runs the next event in the Calendar.
        public void RunNextEvent()
        {
            Event CurrentEvent = EventCalendar.GetNextEvent();
            CurrentTime = CurrentEvent.EventTime;
            CurrentEvent.ProcessEvent();
            EventCalendar.SortEvents();
            UpdateCurrentInQueue();
            UpdateCurrentInEachQueue();
            SimDisplay.RunDisplay();
        }

        // Ends the Simulation
        public void EndSimulation()
        {
            EventCalendar.RemoveAllEvents();
            MessageBox.Show("The Simulation is finished");
        }

        // Add the entity to the correct queue.
        public void AddEntityToQueue(Entity e)
        {
            if (QueueDict.ContainsKey(e.ProductType))
            {
                QueueDict[e.ProductType].AddEntity(e);
            }
        }

        // Get the correct queue and complete the service for the entity.
        public void CompleteService(Entity e)
        {
            if (QueueDict.ContainsKey(e.ProductType))
            {
                QueueDict[e.ProductType].CompleteService(e);
                Stats.IncreaseCompletion(e.ProductType);
            }
        }

        // Get the total number of entities in queues. 
        public void UpdateCurrentInQueue()
        {
            CurrentInQueue = QueueDict.Sum(entityQueue => entityQueue.Value.GetNumInQueue());
        }


        // Updates the statistics for each queue.
        public void UpdateCurrentInEachQueue()
        {
            foreach (KeyValuePair<string, EntityQueue> keyValuePair in QueueDict)
            {
                Stats.UpdateAverageWait(keyValuePair.Value.GetNumInQueue(), keyValuePair.Key);
            }
        }
    }
}
