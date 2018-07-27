using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neasure
{
    public partial class Test : Form
    {
        private string serverAdress;
        private int pingInterval;
        private int mode;

        public Test(string serverAdress, int pingInterval, int mode)
        {
            InitializeComponent();

            this.serverAdress = serverAdress;
            this.pingInterval = pingInterval;
            this.mode = mode;
        }

        private void startTest(string serverAdress, int pingInterval, int mode)
        {
            string resultFile = @"result_" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".txt";
            Console.WriteLine("Creating Result File at: " + resultFile);

            using (var writer = new StreamWriter(resultFile, false))
            {
                // Write a CSV header
                writer.WriteLine("Server Adress;Status;Time;Adress");
                try
                {
                    int count = 0;

                    //TODO Replace While Loop with the Time of the Chosen Mode (1 Hour/24 Hours/7 Days)
                    while (count != 10)
                    {
                        Ping myPing = new Ping();
                        PingReply reply = myPing.Send(serverAdress, pingInterval);
                        if (reply != null)
                        {
                            // Use the overload of WriteLine that accepts string format and arguments
                            Console.WriteLine("Ping at " + serverAdress + " - Status: " + reply.Status + " - Time: " + reply.RoundtripTime + " - Adress: " + reply.Address);
                            writer.WriteLine("{0};{1};{2};{3}", serverAdress, reply.Status, reply.RoundtripTime, reply.Address);

                            //TODO Update Window
                        }

                        Thread.Sleep(pingInterval);
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    // You had a syntax error here
                    MessageBox.Show("An Error Occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // Asking user if he really wants to abort the Test
            var result = MessageBox.Show("All your Measurement Data will be Deletet\nDo you really want to Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            //TODO Zeige den Aktuellen Status
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblTestRunning.Text = "Your Test is Running...";
            startTest(serverAdress, pingInterval, mode);
        }

        private void updateWindow()
        {
            // Do stuff
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
