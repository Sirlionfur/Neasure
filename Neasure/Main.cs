using System;
using System.Windows.Forms;

namespace Neasure
{
    public partial class Main : Form
    {
        private int pingInt;

        public Main()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Check if any mode was chosen
            if (!radioBtnShortTest.Checked && !radioBtnLongTest.Checked && !radioBtnExtremeTest.Checked && !radioBtnDebug.Checked)
            {
                MessageBox.Show("You need to pick a Mode to Test", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Deactivating the Button, so the Test cannot be started twice accidently
            btnStart.Enabled = false;

            try
            {
                // Check which mode the user chose
                int radioSelection = 0;

                if (radioBtnShortTest.Checked) { radioSelection = 0; }
                if (radioBtnLongTest.Checked) { radioSelection = 1; }
                if (radioBtnExtremeTest.Checked) { radioSelection = 2; }
                if (radioBtnDebug.Checked) { radioSelection = 3; }
               
                // Start the Test

                Test test = new Test(1000, radioSelection);
                test.Show();
            } catch(Exception ex)
            {
                // Abort if there was an Error
                MessageBox.Show("An Error Occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
                return;
            }

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
