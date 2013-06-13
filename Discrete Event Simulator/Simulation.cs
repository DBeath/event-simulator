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

        public int CurrentInQueue { get; set; }
        public double CurrentTime;

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

            // Create the queues.
            foreach (KeyValuePair<string, int[]> productType in SimConstants.ProductType)
            {
                QueueDict.Add(productType.Key, new EntityQueue(productType.Key, EventFactory, productType.Value[1], productType.Value[2]));
            }

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
                Event CurrentEvent = EventCalendar.GetNextEvent();
                CurrentTime = CurrentEvent.EventTime;
                CurrentEvent.ProcessEvent();
                EventCalendar.SortEvents();
                UpdateCurrentInQueue();
            }
        }

        // Ends the Simulation
        public void EndSimulation()
        {
            EventCalendar.RemoveAllEvents();
            MessageBox.Show("The Simulation is finished");
            Console.Write(CurrentTime);
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
            }
        }

        // Get the total number of entities in queues. 
        public void UpdateCurrentInQueue()
        {
            CurrentInQueue = QueueDict.Sum(entityQueue => entityQueue.Value.GetNumInQueue());
        }
    }
}
