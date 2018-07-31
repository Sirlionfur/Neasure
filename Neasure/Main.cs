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
            // Check if Text Boxes are Empty
            if (string.IsNullOrEmpty(txtServerAdress.Text)){
                MessageBox.Show("Server Adress cant be Empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any mode was chosen
            if (!radioBtnShortTest.Checked && !radioBtnLongTest.Checked && !radioBtnExtremeTest.Checked && !radioBtnDebug.Checked)
            {
                MessageBox.Show("You need to pick a Mode to Test", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if an Interval was chosen
            if (!radioBtnInterval1Sec.Checked)
            {
                MessageBox.Show("You need to pick an Ping Interval to Test", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Den knopf deaktivieren, sodass nicht mehr als ein test gestartet werden kann
            btnStart.Enabled = false;

            try
            {
                // Überprüfen welchen Modus der Nutzer gewählt hat
                int radioSelection = 0;

                if (radioBtnShortTest.Checked) { radioSelection = 0; }
                if (radioBtnLongTest.Checked) { radioSelection = 1; }
                if (radioBtnExtremeTest.Checked) { radioSelection = 2; }
                if (radioBtnDebug.Checked) { radioSelection = 3; }

                if (radioBtnInterval1Sec.Checked) { pingInt = 1000; }
               
                // Den Test Beginnen

                Test test = new Test(txtServerAdress.Text, pingInt, radioSelection);
                test.Show();
            } catch(Exception ex)
            {
                // Abbruch Falls es ein Error gab
                MessageBox.Show("An Error Occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
                return;
            }

        }
    }
}
