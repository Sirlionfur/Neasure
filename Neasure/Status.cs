using System;
using System.Timers;
using System.Windows.Forms;
using Neasure.Properties;

namespace Neasure
{
    public partial class Status : Form
    {
        // Initialize Variables

        public int AverageTimeoutTime { get; set; }
        public long AverageLatency { get; set; }

        public int Timeouts { get; set; }
        public int TimeoutTime { get; set; } = 0;
        public int TimeoutsInRow { get; set; } = 0;
        public long HighestLatency { get; set; }
        public long LowestLatency { get; set; } = 1000;

        private long Latencies;
        private int LatencyCount;

        public Status()
        {
            InitializeComponent();

            var timer = new System.Timers.Timer(1000) {AutoReset = true};
            timer.Elapsed += UpdateData;
            timer.Enabled = true;

            try
            {
                // Update the Data given from the ongoing Test

                if (TimeoutsInRow != 0)
                {
                    AverageTimeoutTime = TimeoutTime / TimeoutsInRow;
                } else
                {
                    lblAverageDowntime.Text = Resources.None;
                }
                lblTimeouts.Text = Timeouts.ToString();
                lblTimeoutTime.Text = TimeoutTime.ToString();
                lblTimeoutsInRow.Text = TimeoutsInRow.ToString();
                lblAverageDowntime.Text = AverageTimeoutTime + Resources.Seconds;

                lblHighestLatency.Text = HighestLatency + Resources.Milliseconds_Short;
                lblLowestLatency.Text = LowestLatency + Resources.Milliseconds_Short;
                lblAverageLatency.Text = AverageLatency + Resources.Milliseconds_Short;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_UpdateData + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateLatency(long latency)
        {
            if(latency >= HighestLatency) { HighestLatency = latency; }
            if(latency <= LowestLatency) { LowestLatency = latency; }

            Latencies += latency;
            LatencyCount++;

            AverageLatency = Latencies / LatencyCount;
        }

        private void UpdateData(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Update the Data given from the ongoing Test
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (TimeoutsInRow != 0)
                        {
                            AverageTimeoutTime = TimeoutTime / TimeoutsInRow;
                        }
                        lblTimeouts.Text = Timeouts.ToString();
                        lblTimeoutTime.Text = TimeoutTime.ToString();
                        lblTimeoutsInRow.Text = TimeoutsInRow.ToString();
                        lblAverageDowntime.Text = AverageTimeoutTime.ToString();

                        lblHighestLatency.Text = HighestLatency + Resources.Milliseconds_Short;
                        lblLowestLatency.Text = LowestLatency + Resources.Milliseconds_Short;
                        lblAverageLatency.Text = AverageLatency + Resources.Milliseconds_Short;
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_UpdateData + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTimeouts_Click(object sender, EventArgs e)
        {

        }
    }
}
