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
        private static string resultFile;
        private int count = 0;

        private DateTime timeTestStartet;

        private static object writeLock = new object();

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
            lblTestRunning.Text = "Your Test is Running...";

            // Get Date and Time, Create new File and Write the Header
            timeTestStartet = DateTime.Now;
            resultFile = @"result_" + timeTestStartet.ToString("yyyyMMddTHHmmss") + ".txt";
            ThreadPool.QueueUserWorkItem(WriteToFile, "Server Adress;Status;Time;Adress");

            // Start the Test
            backgroundWorkerPing.RunWorkerAsync();
        }

        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
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

                    var msg = serverAdress + ";" + reply.Status + ";" + reply.RoundtripTime + ";" + reply.Address;
                    ThreadPool.QueueUserWorkItem(WriteToFile, msg);

                    backgroundWorkerPing.ReportProgress(count * 10);
                }

                Thread.Sleep(pingInterval);
                count++;
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

        public static void WriteToFile(object msg)
        {
            lock (writeLock)
            {
                var file = resultFile;

                using (var writer = File.AppendText((string)file))
                {
                    writer.WriteLine((string)msg);
                }
            }
        }
    }
}
