using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Check if Text Boxes are Empty
            if (string.IsNullOrEmpty(txtServerAdress.Text) || string.IsNullOrEmpty(txtPingInterval.Text)){
                MessageBox.Show("Server Adress and Ping Interval cant be Empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any mode was chosen
            if (!radioBtnShortTest.Checked && !radioBtnLongTest.Checked && !radioBtnExtremeTest.Checked)
            {
                MessageBox.Show("You need to pick a Mode to Test", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string oldPing = txtPingInterval.Text;
                var newPing = oldPing.PadRight(4, '0');

                int pingInt = Int32.Parse(newPing);

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
