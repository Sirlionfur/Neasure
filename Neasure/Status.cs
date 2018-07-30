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

        private int averageTimeoutTime;
        private int averageLatency;

        public int timeouts { get; set; } = 0;
        public int timeoutTime { get; set; } = 0;
        public int timeoutsInRow { get; set; } = 0;
        public int highestLatency { get; set; } = 0;
        public int lowestLatency { get; set; } = 0;

        public bool dataSent { get; set; } = false;

        public Status(string serverAdress, int mode)
        {
            InitializeComponent();

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += updateData;
            timer.Enabled = true;

            lblServerAdress.Text = serverAdress;
            switch (mode)
            {
                case 0:
                    lblModeChosen.Text = "Short Test (1 Hour)";
                    break;

                case 1:
                    lblModeChosen.Text = "Long Test (24 Hours)";
                    break;

                case 2:
                    lblModeChosen.Text = "Extreme Test (7 Days)";
                    break;

                case 3:
                    lblModeChosen.Text = "Debug Test (30 Seconds)";
                    break;

                default:
                    lblModeChosen.Text = "Error: Invalid Mode";
                    break;
            }

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
