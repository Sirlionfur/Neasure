namespace Neasure
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Test));
            this.lblTestRunning = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.backgroundWorkerPing = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblTestRunning
            // 
            resources.ApplyResources(this.lblTestRunning, "lblTestRunning");
            this.lblTestRunning.Name = "lblTestRunning";
            // 
            // lblRemainingTime
            // 
            resources.ApplyResources(this.lblRemainingTime, "lblRemainingTime");
            this.lblRemainingTime.Name = "lblRemainingTime";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // btnStatus
            // 
            resources.ApplyResources(this.btnStatus, "btnStatus");
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // backgroundWorkerPing
            // 
            this.backgroundWorkerPing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPing_DoWork);
            this.backgroundWorkerPing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPing_RunWorkerCompleted);
            // 
            // Test
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblRemainingTime);
            this.Controls.Add(this.lblTestRunning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestRunning;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPing;
    }
}