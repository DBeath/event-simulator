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
    public class Display
    {
        private Simulation sim;
        private DataGridView calendargrid;
        private ListBox statsbox;
        private DataGridView queuegrid;
        private TextBox txtCurrentTime;
        private string[] displayColumns = new string[]{"Entity ID", "Event", "Event Time", "Product Type", "Start Time", "Begin Wait"};

        public Display(Simulation startSim, DataGridView startCalendarGrid, DataGridView startQueueGrid, ListBox startStatsbox, TextBox txtcurrenttime)
        {
            sim = startSim;
            calendargrid = startCalendarGrid;
            queuegrid = startQueueGrid;
            statsbox = startStatsbox;
            txtCurrentTime = txtcurrenttime;
        }

        public void RunDisplay()
        {
            ClearDataGridView();
            DisplayCalendar();
            DisplayQueues();
            DisplayStats();
        }

        // Displays the Calendar in a DataGridView.
        public void DisplayCalendar()
        {
            foreach (Event thisEvent in sim.EventCalendar.EventList)
            {
                calendargrid.Rows.Add(thisEvent.EventEntity.EntityId, thisEvent.ToString(), ConvertToTime(thisEvent.EventTime),
                                      thisEvent.EventEntity.ProductType, ConvertToTime(thisEvent.EventEntity.StartTimeSystem),
                                      ConvertToTime(thisEvent.EventStartTime));
            }

            calendargrid.Refresh();

            txtCurrentTime.Text = ConvertToTime(sim.CurrentTime);
            txtCurrentTime.Refresh();
        }

        // Displays the enitities currently waiting in the queues.
        public void DisplayQueues()
        {
            foreach (KeyValuePair<string, EntityQueue> queue in sim.QueueDict)
            {
                foreach (Entity entity in queue.Value.ThisEntityQueue)
                {
                    queuegrid.Rows.Add(entity.EntityId, "Begin Service", " -- ", entity.ProductType,
                                       ConvertToTime(entity.StartTimeSystem), ConvertToTime(entity.StartTimeQueue));
                }

                queuegrid.Rows.Add();
            }

            queuegrid.Refresh();
        }

        // Create the columns for the datagridviews.
        public void CreateColumns()
        {
            foreach (var column in displayColumns)
            {
                calendargrid.Columns.Add(column, column);
                queuegrid.Columns.Add(column, column);
            }
        }

        // Clears the DataGridView.
        public void ClearDataGridView()
        {
            calendargrid.Rows.Clear();
            calendargrid.Refresh();

            queuegrid.Rows.Clear();
            queuegrid.Refresh();
        }

        // Displays the statistics of the current simulation.
        public void DisplayStats()
        {
            statsbox.Items.Clear();

            statsbox.Items.Add("Busy Signal Count: " + sim.Stats.BusySignalCount);
            foreach (KeyValuePair<string, double[]> valuePair in sim.Stats.StatsDict)
            {
                statsbox.Items.Add("Completions (" + valuePair.Key + ") Count: " + valuePair.Value[0]);
                statsbox.Items.Add("Average number waiting (" + valuePair.Key + "): " + valuePair.Value[3]);
            }

            statsbox.Refresh();
        }

        // Convert the time in seconds to hour minute second format.
        public string ConvertToTime(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);

            string time = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);

            return time;
        }

    }
}
