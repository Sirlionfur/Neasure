using System.Windows.Forms;
using Neasure.Properties;

namespace Neasure {
	public partial class Result : Form
    {
        private string _pingFile;
        private string _speedFile;

		public Result (Status status, string pingFile, string speedFile)
		{
			InitializeComponent();

			lblTimeouts.Text = status.Timeouts.ToString();
			lblTimeoutsInRow.Text = status.TimeoutsInRow.ToString();
			lblTimeoutTime.Text = status.TimeoutTime + Resources.Seconds;

			lblHighestLatency.Text = status.HighestLatency + Resources.Milliseconds_Short;
			lblLowestLatency.Text = status.LowestLatency + Resources.Milliseconds_Short;

			lblAverageDowntime.Text = status.AverageTimeoutTime.ToString();
			lblAverageLatency.Text = status.AverageLatency + Resources.Milliseconds_Short;

            _pingFile = pingFile;
            _speedFile = speedFile;
        }

		protected override void OnFormClosing (FormClosingEventArgs e)
		{
			DialogResult dialog = MessageBox.Show(Resources.Confirm_Exit,Resources.WarningTitle,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
			if (dialog == DialogResult.Yes) {
				Application.Exit();
			} else {
				e.Cancel = true;
			}
		}

        private void btnFormOpen_Click(object sender, System.EventArgs e)
        {
            FirebaseForm form = new FirebaseForm(_pingFile, _speedFile);
            form.Show();
        }
    }
}
