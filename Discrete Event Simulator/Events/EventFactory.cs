using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class EventFactory
    {
        private Simulation Sim;
        private RandomValue rGen;


        // Constructor
        public EventFactory(Simulation startSim, RandomValue startRGen)
        {
            Sim = startSim;
            rGen = startRGen;
        }

        //public Event CreateEvent(SimulationConstants.EventType eventType, Entity e)
        //{
        //    Event newEvent;
        //    switch (eventType)
        //    {
        //        case SimulationConstants.EventType.Arrive:
        //            newEvent = CreateArrive(e);    
        //            break;
        //        case SimulationConstants.EventType.JoinQueue:
        //            newEvent = CreateJoinQueue(e);
        //            break;
        //        case SimulationConstants.EventType.CompleteService:
        //            newEvent = CreateCompleteService(e);
        //            break;

        //    }
        //    return newEvent;
        //}

        // Create an Arrive Event
        public void CreateArrive(Entity e)
        {
            // Create the new event. The event time is set to the previously generated arrival time
            // of the entity.
            Event newEvent = new Arrive(e.StartTimeSystem, e, Sim);
            // Add the event to the calendar.
            Sim.EventCalendar.AddEvent(newEvent);
        }

        // Create a Join Queue Event
        public void CreateJoinQueue(Entity e)
        {
            // Roll to find the time the Join Queue event will fire.
            int joinTime = rGen.Roll(Sim.SimConstants.JoinQueueMultiplier) + Sim.CurrentTime;
            // Create the new event.
            Event newEvent = new JoinQueue(joinTime, e, Sim);
            newEvent.EventStartTime = Sim.CurrentTime;
            // Add the event to the calendar.
            Sim.EventCalendar.AddEvent(newEvent);
        }

        // Create a Complete Service Event
        public void CreateCompleteService(Entity e, double serviceMultiplier)
        {
            // Set the exit queue time of the entity
            e.ExitTimeQueue = Sim.CurrentTime;
            // Roll to find the time that the Complete Service Event will fire.
            int serviceTime = rGen.Roll(serviceMultiplier) + Sim.CurrentTime;
            // Create the new event.
            Event newEvent = new CompleteService(serviceTime, e, Sim);
            newEvent.EventStartTime = Sim.CurrentTime;
            // Add the event to the calendar.
            Sim.EventCalendar.AddEvent(newEvent);
        }

        // Create an End Replication Event
        public void CreateEndReplication(Entity e)
        {
            Event newEvent = new EndReplication(Sim.SimConstants.SimulationEndTime, e, Sim);
            Sim.EventCalendar.AddEvent(newEvent);
        }
    }
}
