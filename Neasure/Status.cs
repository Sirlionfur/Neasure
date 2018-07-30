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
        public int averageLatency { get; set; }

        public int timeouts { get; set; } = 0;
        public int timeoutTime { get; set; } = 0;
        public int timeoutsInRow { get; set; } = 0;
        public int highestLatency { get; set; } = 0;
        public int lowestLatency { get; set; } = 0;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Update Data:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                lblHighestLatency.Text = highestLatency.ToString() + " ms";
                lblLowestLatency.Text = lowestLatency.ToString() + " ms";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Update Data:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
