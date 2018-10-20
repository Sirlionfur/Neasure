using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Neasure
{
    public partial class Status : Form
    {
        // Initialize Variables

        public int averageTimeoutTime { get; set; }
        public long averageLatency { get; set; }

        public int timeouts { get; set; } = 0;
        public int timeoutTime { get; set; } = 0;
        public int timeoutsInRow { get; set; } = 0;
        public long highestLatency { get; set; } = 0;
        public long lowestLatency { get; set; } = 0;

        public bool dataSent { get; set; } = false;

        public Status()
        {
            InitializeComponent();

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += updateData;
            timer.Enabled = true;

            try
            {
                // Update the Data given from the ongoing Test

                if (timeoutsInRow != 0)
                {
                    averageTimeoutTime = timeoutTime / timeoutsInRow;
                } else
                {
                    lblAverageDowntime.Text = "None";
                }
                lblTimeouts.Text = timeouts.ToString();
                lblTimeoutTime.Text = timeoutTime.ToString();
                lblTimeoutsInRow.Text = timeoutsInRow.ToString();
                lblAverageDowntime.Text = averageTimeoutTime.ToString() + " Seconds";

                lblHighestLatency.Text = highestLatency.ToString() + " ms";
                lblLowestLatency.Text = lowestLatency.ToString() + " ms";
                lblAverageLatency.Text = averageLatency.ToString() + " ms";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Update Data:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateLatency(long latency)
        {
            if(latency >= highestLatency) { highestLatency = latency; }
            if(latency <= lowestLatency) { lowestLatency = latency; }

            averageLatency = highestLatency - lowestLatency;
        }

        private void updateData(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Update the Data given from the ongoing Test

                if (timeoutsInRow != 0)
                {
                    averageTimeoutTime = timeoutTime / timeoutsInRow;
                }
                lblTimeouts.Text = timeouts.ToString();
                lblTimeoutTime.Text = timeoutTime.ToString();
                lblTimeoutsInRow.Text = timeoutsInRow.ToString();
                lblAverageDowntime.Text = averageTimeoutTime.ToString();

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        lblHighestLatency.Text = highestLatency.ToString() + " ms";
                        lblLowestLatency.Text = lowestLatency.ToString() + " ms";
                        lblAverageLatency.Text = averageLatency.ToString() + " ms";
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Update Data:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
