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
            this.lblTestRunning = new System.Windows.Forms.Label();
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTestRunning
            // 
            this.lblTestRunning.AutoSize = true;
            this.lblTestRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestRunning.Location = new System.Drawing.Point(12, 9);
            this.lblTestRunning.Name = "lblTestRunning";
            this.lblTestRunning.Size = new System.Drawing.Size(244, 31);
            this.lblTestRunning.TabIndex = 0;
            this.lblTestRunning.Text = "Press Start to Start";
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Location = new System.Drawing.Point(15, 59);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(86, 13);
            this.lblRemainingTime.TabIndex = 1;
            this.lblRemainingTime.Text = "Remaining Time:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(107, 59);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "lblTime";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(18, 75);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(285, 23);
            this.progressBar.TabIndex = 3;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(18, 104);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(145, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Current Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAbort.Location = new System.Drawing.Point(169, 104);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(134, 23);
            this.btnAbort.TabIndex = 5;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 133);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(285, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 165);
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
            this.Text = "Neasure - Testing...";
            this.Load += new System.EventHandler(this.Test_Load);
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
    }
}