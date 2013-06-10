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

        public Event CreateEvent(Constants.EventType eventType, Entity e)
        {
                switch (eventType)
                {
                    case Constants.EventType.Arrive:

                        break;
                    case Constants.EventType.JoinQueue:
                        break;
                    case Constants.EventType.CompleteService:
                        break;

                }
        }

        public Event CreateArrive(Entity e)
        {
            
        }

        public Event CreateJoinQueue(Entity e)
        {
            
        }

        public Event CreateCompleteService(Entity e)
        {
            
        }
    }
}
