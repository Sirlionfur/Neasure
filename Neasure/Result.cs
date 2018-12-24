using System.Windows.Forms;
using Neasure.Properties;

namespace Neasure
{
    public partial class Result : Form
    {
        public Result(Status status)
        {
            InitializeComponent();

            lblTimeouts.Text = status.Timeouts.ToString();
            lblTimeoutsInRow.Text = status.TimeoutsInRow.ToString();
            lblTimeoutTime.Text = status.TimeoutTime + Resources.Seconds;

            lblHighestLatency.Text = status.HighestLatency + Resources.Milliseconds_Short;
            lblLowestLatency.Text = status.LowestLatency + Resources.Milliseconds_Short;

            lblAverageDowntime.Text = status.AverageTimeoutTime.ToString();
            lblAverageLatency.Text = status.AverageLatency + Resources.Milliseconds_Short;

	    //TODO Close the Whole Application when window closed?
        }
    }
}
