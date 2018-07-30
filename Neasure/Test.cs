using System;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
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
        private System.Timers.Timer timer;

        private DateTime timeTestStartet;

        private static object writeLock = new object();

        public Test(string serverAdress, int pingInterval, int mode)
        {
            InitializeComponent();

            // Set the Background Workers Settings
            backgroundWorkerPing.DoWork += backgroundWorkerPing_DoWork;
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
            Status status = new Status(serverAdress, mode);
            status.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var TimeMiliseconds = 0;
            btnStart.Enabled = false;

            // Set Timers Time according to the Mode
            switch (mode)
            {
                case 0:
                    TimeMiliseconds = 3600000;
                    break;

                case 1:
                    TimeMiliseconds = 86400000;
                    break;

                case 2:
                    TimeMiliseconds = 604800000;
                    break;
                case 3:
                    TimeMiliseconds = 30000;
                    break;

                default:
                    MessageBox.Show("Error while Checking for Chosen Mode", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnStart.Enabled = true;
                    return;
            }

            lblTestRunning.Text = "Your Test is Running...";

            progressBar.Maximum = TimeMiliseconds;
            timer = new System.Timers.Timer(TimeMiliseconds);
            timer.AutoReset = false;
            timer.Elapsed += HandleTimer;
            timer.Enabled = true;

            // Get Date and Time, Create new File and Write the Header
            timeTestStartet = DateTime.Now;
            resultFile = @"result_" + timeTestStartet.ToString("yyyyMMddTHHmmss") + ".txt";
            ThreadPool.QueueUserWorkItem(WriteToFile, "Status;Time;Adress");

            // Start the Test
            backgroundWorkerPing.RunWorkerAsync();
        }

        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            while (timer.Enabled)
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send(serverAdress, pingInterval);
                if (reply != null)
                {
                    // Use the overload of WriteLine that accepts string format and arguments
                    Console.WriteLine("Ping at " + serverAdress + " - Status: " + reply.Status + " - Time: " + reply.RoundtripTime + " - Adress: " + reply.Address);

                    var msg = reply.Status + ";" + reply.RoundtripTime + ";" + reply.Address;
                    ThreadPool.QueueUserWorkItem(WriteToFile, msg);
                }

                Thread.Sleep(pingInterval);
            }
        }

        private void backgroundWorkerPing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            lblTestRunning.Text = "Test Complete!";

            //TODO Open Results
        }

        // The File Writer Function working in the Background

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

        // Declaring the Events for the Timer

        private void HandleTimer(object sender, ElapsedEventArgs e)
        {
            backgroundWorkerPing.CancelAsync();
            timer.Enabled = false;
        }
    }
}
