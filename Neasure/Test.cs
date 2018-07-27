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
        private string resultFile;
        private int count = 0;

        private DateTime timeTestStartet = DateTime.Now;

        public Test(string serverAdress, int pingInterval, int mode)
        {
            InitializeComponent();

            backgroundWorkerPing.DoWork += backgroundWorkerPing_DoWork;
            backgroundWorkerPing.ProgressChanged += backgroundWorkerPing_ProgressChanged;
            backgroundWorkerPing.WorkerReportsProgress = true;
            backgroundWorkerPing.WorkerSupportsCancellation = true;

            this.serverAdress = serverAdress;
            this.pingInterval = pingInterval;
            this.mode = mode;
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
            // Start test if the User wants to Start
            lblTestRunning.Text = "Your Test is Running...";

            backgroundWorkerPing.RunWorkerAsync();
        }

        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            resultFile = @"result_" + timeTestStartet.ToString("yyyyMMddTHHmmss") + ".txt";
            using (var writer = new StreamWriter(resultFile, false))
            {
                writer.WriteLine("Server Adress;Status;Time;Adress");
                try
                {
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

                            backgroundWorkerPing.ReportProgress(count * 10);
                        }

                        Thread.Sleep(pingInterval);
                        count++;
                        Console.WriteLine(count);
                    }
                }
                catch (Exception ex)
                {
                    // You had a syntax error here
                    MessageBox.Show("An Error Occured:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorkerPing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            if(e.ProgressPercentage != 0)
            {
                double percentageComplete = (double)e.ProgressPercentage / count * 10;

                TimeSpan timeSinceStart = DateTime.Now.Subtract(timeTestStartet);
                TimeSpan totalTime = TimeSpan.FromMilliseconds(timeSinceStart.TotalMilliseconds / percentageComplete);
                TimeSpan timeLeft = totalTime - timeSinceStart;

                lblTime.Text = timeLeft.ToString();
            }
        }
    }
}
