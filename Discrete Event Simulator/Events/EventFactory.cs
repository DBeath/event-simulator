using Discrete_Event_Simulator.Entities;

namespace Discrete_Event_Simulator.Events
{
    public class EventFactory
    {
        private Simulation Simulation;
        private RandomValue rGen;

        public EventFactory(Simulation startSim, RandomValue startRGen)
        {
            Simulation = startSim;
            rGen = startRGen;
        }

        public Event CreateEvent(SimulationConstants.EventType eventType, Entity e)
        {
            Event newEvent;
            switch (eventType)
            {
                case SimulationConstants.EventType.Arrive:
                    newEvent = CreateArrive(e);    
                    break;
                case SimulationConstants.EventType.JoinQueue:
                    newEvent = CreateJoinQueue(e);
                    break;
                case SimulationConstants.EventType.CompleteService:
                    newEvent = CreateCompleteService(e);
                    break;

            }
            return newEvent;
        }

        public Event CreateArrive(Entity e)
        {
            double arrivalTime = rGen.Roll(Simulation.SimulationConstants.)
            Arrive event = new Arrive()
        }

        public Event CreateJoinQueue(Entity e)
        {
            
        }

        public Event CreateCompleteService(Entity e)
        {
            
        }
    }
}
