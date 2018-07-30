using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neasure
{
    public partial class Result : Form
    {
        public Result(Status status)
        {
            InitializeComponent();

            lblTimeouts.Text = status.timeouts.ToString();
            lblTimeoutsInRow.Text = status.timeoutsInRow.ToString();
            lblTimeoutTime.Text = status.timeoutTime.ToString() + " Seconds";

            lblHighestLatency.Text = status.highestLatency.ToString() + " ms";
            lblLowestLatency.Text = status.lowestLatency.ToString() + " ms";

            lblAverageDowntime.Text = status.averageTimeoutTime.ToString();
            lblAverageLatency.Text = status.averageLatency.ToString() + " ms";
        }
    }
}
