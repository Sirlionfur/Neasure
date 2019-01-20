using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Neasure.Properties;
using Timer = System.Timers.Timer;

namespace Neasure {
    [Flags]
    public enum EXECUTION_STATE : uint
    {
        ES_CONTINUOUS = 0x80000000,
        ES_SYSTEM_REQUIRED = 0x00000001,
    }

	public partial class Test : Form {
		// Initialize Values
		internal string CurrentAdress;
		private readonly int _pingInterval;
		private readonly int _mode;
		private static string _pingFile;
        private static string _speedFile;
		private Timer _timer;
		private Timer _speedTestTimer;
		private List<string> _speedTests = new List<string>();
		private Boolean _manualExit = true;

		private DateTime _timeTestStartet;

		private static readonly object WriteLock = new object();

		private readonly Status _status = new Status();

		private int _timeMiliseconds;

        private string documentsFolder;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

		public Test (int pingInterval,int mode)
		{
			InitializeComponent();

            documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
            Directory.CreateDirectory(documentsFolder + "\\Neasure");

            // Set the Background Workers Settings
            backgroundWorkerPing.DoWork += backgroundWorkerPing_DoWork;
			backgroundWorkerPing.WorkerReportsProgress = true;
			backgroundWorkerPing.WorkerSupportsCancellation = true;

			// Set the Private Values to the Values given from the Main Form
			_pingInterval = pingInterval;
			_mode = mode;
		}

		private void btnAbort_Click (object sender,EventArgs e)
		{
            // Asking user if he really wants to abort the Test
            var result = MessageBox.Show(Resources.Warning_DataDeleted,Resources.WarningTitle,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) {
                Environment.Exit(1);
            }
		}

		private void btnStatus_Click (object sender,EventArgs e)
		{
			_status.Show();
		}

		private void btnStart_Click (object sender,EventArgs e)
        {
			btnStart.Enabled = false;
			CurrentAdress = "8.8.8.8";

			// Set Timers Time according to the Mode
			switch (_mode) {
			case 0:
				_timeMiliseconds = 3600000;
				break;

			case 1:
				_timeMiliseconds = 86400000;
				break;

			case 2:
				_timeMiliseconds = 604800000;
				break;
			case 3:
				_timeMiliseconds = 30000;
				break;

			default:
				MessageBox.Show(Resources.Error_CheckingChosenMode,Resources.ErrorTitle,MessageBoxButtons.OK,MessageBoxIcon.Error);
				btnStart.Enabled = true;
				return;
			}

			lblTestRunning.Text = Resources.Info_TestRunning;

			// Initialize Proper Timer for chosen mode
			progressBar.Maximum = _timeMiliseconds;
			_timer = new Timer(_timeMiliseconds) { AutoReset = false };
			_timer.Elapsed += HandleTimer;
			_timer.Enabled = true;

            // Initialize Speed Test Timer
            #if DEBUG
            _speedTestTimer = new Timer(10000) { AutoReset = true };
            #else
            _speedTestTimer = new Timer(900000) { AutoReset = true };
            #endif

            _speedTestTimer.Elapsed += HandleSpeedTimer;
			_speedTestTimer.Enabled = true;

			// Get Date and Time, Create new File and Write the Header
			_timeTestStartet = DateTime.Now;
			_pingFile = documentsFolder + "\\Neasure\\result_" + _timeTestStartet.ToString("yyyyMMddT_HH-mm-ss") + ".txt";
            _speedFile = documentsFolder + "\\Neasure\\speed_" + _timeTestStartet.ToString("yyyyMMddT_HH-mm-ss") + ".txt";
			ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { "Mac Address;Test Time;Test Date;Ping 8.8.8.8;Ping 8.8.4.4;Ping Default Gateway;Latency",_pingFile });
			_speedTests.Add("Test Started;Download Duration;File Size;Download Speed");

            // Setting Execution State so the Sleep Mode wont Activate while Testing
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);

			// Start the Test
			backgroundWorkerPing.RunWorkerAsync();
		}

		private void backgroundWorkerPing_DoWork (object sender,DoWorkEventArgs e)
		{
			while (_timer.Enabled) {
				try {
					var macAddr =
						(
						    from nic in NetworkInterface.GetAllNetworkInterfaces()
						    where nic.OperationalStatus == OperationalStatus.Up
						    select nic.GetPhysicalAddress().ToString()
						).FirstOrDefault();

					var myPing = new Ping();

					var googleReply = myPing.Send("8.8.8.8",_pingInterval);
					if (googleReply.Status != IPStatus.Success) {
						var googleReserve = myPing.Send("8.8.4.4",_pingInterval);
						if (googleReserve.Status != IPStatus.Success) {
							var routerReply = myPing.Send(GetDefaultGateway().ToString(),_pingInterval);

							var msg = macAddr + ";" + DateTime.Now.ToString("HH:mm:ss") + ";" + DateTime.Now.ToString("yyyy-MM-dd") + ";Timeout;Timeout;" + routerReply.Status + ";" + routerReply.RoundtripTime;
							ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { msg,_pingFile });
							_status.Timeouts++;
						} else {
							var msg = macAddr + ";" + DateTime.Now.ToString("HH:mm:ss") + ";" + DateTime.Now.ToString("yyyy-MM-dd") + ";Timeout;" + googleReserve.Status + ";Not Tested;" + googleReserve.RoundtripTime;
							_status.UpdateLatency(googleReserve.RoundtripTime);
							ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { msg,_pingFile });
						}
					} else {
						_status.SuccessfulPings++;
						var msg = macAddr + ";" + DateTime.Now.ToString("HH:mm:ss") + ";" + DateTime.Now.ToString("yyyy-MM-dd") + ";" + googleReply.Status + ";Not Tested;Not Tested;" + googleReply.RoundtripTime;
						_status.UpdateLatency(googleReply.RoundtripTime);
						ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { msg,_pingFile });
					}

					if (InvokeRequired) {
						BeginInvoke(new Action(() => {
							_timeMiliseconds -= 1000;
							progressBar.Value = progressBar.Value + _pingInterval;
							lblTime.Text = Math.Truncate(TimeSpan.FromMilliseconds(_timeMiliseconds).TotalHours * 100) / 100 + Resources.HoursLeft;
						}));
					}

					Thread.Sleep(_pingInterval);
				} catch (Exception ex) {
					//TODO Make an Window that shows the Errors while the Test is running
					ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { ex.Message,"error.log" });
				}
			}
		}

		private void backgroundWorkerPing_RunWorkerCompleted (object sender,RunWorkerCompletedEventArgs e)
		{
			_speedTestTimer.Stop();
			foreach (var test in _speedTests) {
				ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { test,_speedFile });
			}

			progressBar.Value = 0;
			lblTestRunning.Text = Resources.Info_TestComplete;
            
            // Reset Execution State to Default
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);

            // Show Results and Close Current Window
			var result = new Result(_status, _pingFile, _speedFile);
			result.Show();
            _status.Close();
			_manualExit = false;
			Close();
		}

		private void backgroundWorkerSpeedTest_DoWork (object sender,DoWorkEventArgs e)
		{
			try {
				// Create new Temporary File and Download File while stopping time
				var client = new WebClient();
				var sw = new Stopwatch();
				const string tempFile = "temp.tmp";

				sw.Start();
				client.DownloadFile("https://speed.hetzner.de/100MB.bin",tempFile);
				sw.Stop();

				var fileInfo = new FileInfo(tempFile);
				var speed = fileInfo.Length / sw.Elapsed.Seconds;

				_speedTests.Add(DateTime.Now.ToString("HH:mm:ss") + ";" + sw.Elapsed + ";" + fileInfo.Length.ToString("N0") + ";" + speed.ToString("N0"));
			} catch (Exception ex) {
				//TODO Make an Window that shows the Errors while the Test is running
				ThreadPool.QueueUserWorkItem(WriteToFile,new object[] { ex.Message,"error.log" });
			}
		}

		private void backgroundWorkerSpeedTest_RunWorkerCompleted (object sender,RunWorkerCompletedEventArgs e)
		{
			// Delete Temporary File
			File.Delete("temp.tmp");
		}

		// The File Writer Function working in the Background

		private static void WriteToFile (object state)
		{
			var array = state as object[];
			if (array == null) return;
			var msg = array[0].ToString();
			var file = array[1].ToString();

			lock (WriteLock) {
				using (var writer = File.AppendText(file)) {
					writer.WriteLine(msg);
				}
			}
		}

		// Declaring the Events for the Timers

		private void HandleTimer (object sender,ElapsedEventArgs e)
		{
			backgroundWorkerPing.CancelAsync();
			_timer.Enabled = false;
		}

		private void HandleSpeedTimer (object sender,ElapsedEventArgs e)
		{
			backgroundWorkerSpeedTest.RunWorkerAsync();
		}

		private static IPAddress GetDefaultGateway ()
		{
			return NetworkInterface
				.GetAllNetworkInterfaces()
				.Where(n => n.OperationalStatus == OperationalStatus.Up)
				.Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				.SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
				.Select(g => g?.Address)
				.Where(a => a != null)
				.FirstOrDefault();
		}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Asking user if he really wants to abort the Test
            if (!_manualExit) return;
            var result = MessageBox.Show(Resources.Warning_DataDeleted,Resources.WarningTitle,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            e.Cancel = (result == DialogResult.No);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_manualExit)
            {
                Environment.Exit(1);
            }
        }
    }
}
