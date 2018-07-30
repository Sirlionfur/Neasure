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

        public int timeouts { get; set; }
        public int timeoutTime { get; set; }
        public int timeoutsInRow { get; set; }
        public int highestLatency { get; set; }
        public int lowestLatency { get; set; }

        public Status(string serverAdress, int mode)
        {
            InitializeComponent();

            System.Timers.Timer timer = new System.Timers.Timer(5000);
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

                averageTimeoutTime = timeoutTime / timeoutsInRow;

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

                averageTimeoutTime = timeoutTime / timeoutsInRow;

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
