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
        private int pingInterval;
        private int mode;
        private static string resultFile;
        private System.Timers.Timer timer;
        private System.Timers.Timer timeoutTimer = new System.Timers.Timer(1000);

        private DateTime timeTestStartet;

        private static object writeLock = new object();

        private Status status = new Status();
        private bool timeoutRow = false;

        public Test(int pingInterval, int mode)
        {
            InitializeComponent();

            // Set the Background Workers Settings
            backgroundWorkerPing.DoWork += backgroundWorkerPing_DoWork;
            backgroundWorkerPing.WorkerReportsProgress = true;
            backgroundWorkerPing.WorkerSupportsCancellation = true;

            // Set the Private Values to the Values given from the Main Form
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
            ThreadPool.QueueUserWorkItem(WriteToFile, "Status;Latency;Adress;Test Time");

            // Start the Test
            backgroundWorkerPing.RunWorkerAsync();
        }

        private void backgroundWorkerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            while (timer.Enabled)
            {
                try
                {
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send("8.8.8.8", pingInterval);
                    if (reply != null)
                    {
                        // Use the overload of WriteLine that accepts string format and arguments
                        Console.WriteLine("Ping at 8.8.8.8 - Status: " + reply.Status + " - Time: " + reply.RoundtripTime + " - Adress: " + reply.Address);

                        var msg = reply.Status + ";" + reply.RoundtripTime + ";" + reply.Address + ";" + DateTime.Now.ToString("HH:mm:ss");
                        ThreadPool.QueueUserWorkItem(WriteToFile, msg);


                        //TODO Creating a Better Timeouts in a Row Counter and Better Timeout Timer
                        if (reply.Status == IPStatus.TimedOut)
                        {
                            timeoutTimer.AutoReset = true;
                            timeoutTimer.Elapsed += timeoutTimerHandle;
                            timeoutTimer.Enabled = true;

                            status.timeouts++;
                            if(timeoutRow == true)
                            {
                                status.timeoutsInRow++;
                            } else
                            {
                                timeoutRow = true;
                            }
                        } else if (reply.Status == IPStatus.Success)
                        {
                            timeoutTimer.Enabled = false;
                            timeoutRow = false;
                        }
                    }

                    Thread.Sleep(pingInterval);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while Pinging:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorkerPing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            lblTestRunning.Text = "Test Complete!";

            Result result = new Result(status);
            result.Show();
            this.Close();
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

        private void timeoutTimerHandle(object sender, ElapsedEventArgs e)
        {
            status.timeoutTime++;
        }
    }
}
