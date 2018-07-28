using System;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace Neasure
{
    public partial class Test : Form
    {
        // Initialize Values
        private string serverAdress;
        private int pingInterval;
        private int mode;
        private string resultFile;
        private int count = 0;

        private DateTime timeTestStartet;

        public Test(string serverAdress, int pingInterval, int mode)
        {
            InitializeComponent();

            // Set the Background Workers Settings
            backgroundWorkerPing.DoWork += backgroundWorkerPing_DoWork;
            backgroundWorkerPing.ProgressChanged += backgroundWorkerPing_ProgressChanged;
            backgroundWorkerPing.WorkerReportsProgress = true;
            backgroundWorkerPing.WorkerSupportsCancellation = true;

            // Set the Private Values to the Values given from the Main Form
            this.serverAdress = serverAdress;
            this.pingInterval = pingInterval;
            this.mode = mode;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            // Asking user if he really wants to abort the Test
            var result = MessageBox.Show("All your Measurement Data will be Deletet\nDo you really want to Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                backgroundWorkerPing.CancelAsync();
                Thread.Sleep(700);
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

            timeTestStartet = DateTime.Now;

            backgroundWorkerPing.RunWorkerAsync();
        }

        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            resultFile = @"result_" + timeTestStartet.ToString("yyyyMMddTHHmmss") + ".txt";
            using (var writer = new StreamWriter(resultFile, false))
            {
                writer.WriteLine("Server Adress;Status;Time;Adress");
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
                }
            }
        }

        private void backgroundWorkerPing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update Progress Bar and the Remaining Time Label according to the Progress
            //TODO Repair remaining time label
            progressBar.Value = e.ProgressPercentage;

            if (e.ProgressPercentage != 0)
            {
                double percentageComplete = (double)e.ProgressPercentage / count * 10;

                TimeSpan timeSinceStart = DateTime.Now.Subtract(timeTestStartet);
                TimeSpan totalTime = TimeSpan.FromMilliseconds(timeSinceStart.TotalMilliseconds / percentageComplete);
                TimeSpan timeLeft = totalTime - timeSinceStart;

                lblTime.Text = timeLeft.ToString();
            }
        }

        private void backgroundWorkerPing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            lblTestRunning.Text = "Test Complete!";

            //TODO Open Results
        }
    }
}
