using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Discrete_Event_Simulator.Entities;
using Discrete_Event_Simulator.Events;

namespace Discrete_Event_Simulator
{
    public partial class Form1 : Form
    {
        public Simulation Sim;
        public EventFactory SimEventFactory;
        public EntityFactory SimEntityFactory;
        public SimulationConstants SimConstants;
        public RandomValue SimRandomValue;
        public Display SimDisplay;

        public Form1()
        {
            InitializeComponent();

            SimConstants = new SimulationConstants();
            Sim = new Simulation();
            
            SimRandomValue = new RandomValue();
            SimEntityFactory = new EntityFactory(SimRandomValue);
            SimEventFactory = new EventFactory(Sim, SimRandomValue);
            SimDisplay = new Display(Sim, CalendarGrid, QueueGrid, statsBox, txtCurrentTime);

            Sim.EventFactory = SimEventFactory;
            Sim.EntityFactory = SimEntityFactory;
            Sim.SimConstants = SimConstants;
            Sim.SimDisplay = SimDisplay;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sim.IntitialiseSimulation(SimConstants);

            //foreach (Event thisevent in Sim.EventCalendar.EventList)
            //{
            //    listBox1.Items.Add(thisevent.EventEntity.EntityId + ", " + thisevent.EventEntity.StartTimeSystem + "," + thisevent.EventTime);
            //}
            Sim.RunAllEvents();
        }
    }
}
