using System;
using System.Windows.Forms;
using Neasure.Properties;

namespace Neasure
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Check if any mode was chosen
            if (!radioBtnShortTest.Checked && !radioBtnLongTest.Checked && !radioBtnExtremeTest.Checked && !radioBtnDebug.Checked)
            {
                MessageBox.Show(Resources.Error_PickMode, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Deactivating the Button, so the Test cannot be started twice accidentally
            btnStart.Enabled = false;

            try
            {
                // Check which mode the user chose
                var radioSelection = 0;

                if (radioBtnShortTest.Checked) { radioSelection = 0; }
                if (radioBtnLongTest.Checked) { radioSelection = 1; }
                if (radioBtnExtremeTest.Checked) { radioSelection = 2; }
                if (radioBtnDebug.Checked) { radioSelection = 3; }
               
                // Start the Test

                var test = new Test(1000, radioSelection);
                test.Show();
            } catch(Exception ex)
            {
                // Abort if there was an Error
                MessageBox.Show(Resources.Error_General + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
            }

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }
    }
}
