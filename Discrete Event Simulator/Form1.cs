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

        public Form1()
        {
            InitializeComponent();

            Sim = new Simulation();
            SimConstants = new SimulationConstants();
            SimRandomValue = new RandomValue();
            SimEntityFactory = new EntityFactory(SimRandomValue, SimConstants);
            SimEventFactory = new EventFactory(Sim, SimRandomValue);

            Sim.EventFactory = SimEventFactory;
            Sim.EntityFactory = SimEntityFactory;
            Sim.SimulationConstants = SimConstants;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
