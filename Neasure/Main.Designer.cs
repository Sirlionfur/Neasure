namespace Neasure
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServerAdress = new System.Windows.Forms.TextBox();
            this.lblServerAdress = new System.Windows.Forms.Label();
            this.lblPingInterval = new System.Windows.Forms.Label();
            this.txtPingInterval = new System.Windows.Forms.TextBox();
            this.groupTestModes = new System.Windows.Forms.GroupBox();
            this.radioBtnExtremeTest = new System.Windows.Forms.RadioButton();
            this.radioBtnLongTest = new System.Windows.Forms.RadioButton();
            this.radioBtnShortTest = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupTestModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerAdress
            // 
            this.txtServerAdress.Location = new System.Drawing.Point(94, 6);
            this.txtServerAdress.Name = "txtServerAdress";
            this.txtServerAdress.Size = new System.Drawing.Size(285, 20);
            this.txtServerAdress.TabIndex = 0;
            // 
            // lblServerAdress
            // 
            this.lblServerAdress.AutoSize = true;
            this.lblServerAdress.Location = new System.Drawing.Point(12, 9);
            this.lblServerAdress.Name = "lblServerAdress";
            this.lblServerAdress.Size = new System.Drawing.Size(76, 13);
            this.lblServerAdress.TabIndex = 1;
            this.lblServerAdress.Text = "Server Adress:";
            // 
            // lblPingInterval
            // 
            this.lblPingInterval.AutoSize = true;
            this.lblPingInterval.Location = new System.Drawing.Point(12, 45);
            this.lblPingInterval.Name = "lblPingInterval";
            this.lblPingInterval.Size = new System.Drawing.Size(132, 13);
            this.lblPingInterval.TabIndex = 4;
            this.lblPingInterval.Text = "Ping Interval (In Seconds):";
            // 
            // txtPingInterval
            // 
            this.txtPingInterval.Location = new System.Drawing.Point(15, 61);
            this.txtPingInterval.Name = "txtPingInterval";
            this.txtPingInterval.Size = new System.Drawing.Size(59, 20);
            this.txtPingInterval.TabIndex = 5;
            // 
            // groupTestModes
            // 
            this.groupTestModes.Controls.Add(this.radioBtnExtremeTest);
            this.groupTestModes.Controls.Add(this.radioBtnLongTest);
            this.groupTestModes.Controls.Add(this.radioBtnShortTest);
            this.groupTestModes.Location = new System.Drawing.Point(179, 45);
            this.groupTestModes.Name = "groupTestModes";
            this.groupTestModes.Size = new System.Drawing.Size(200, 100);
            this.groupTestModes.TabIndex = 6;
            this.groupTestModes.TabStop = false;
            this.groupTestModes.Text = "Test Modes:";
            // 
            // radioBtnExtremeTest
            // 
            this.radioBtnExtremeTest.AutoSize = true;
            this.radioBtnExtremeTest.Location = new System.Drawing.Point(6, 65);
            this.radioBtnExtremeTest.Name = "radioBtnExtremeTest";
            this.radioBtnExtremeTest.Size = new System.Drawing.Size(129, 17);
            this.radioBtnExtremeTest.TabIndex = 2;
            this.radioBtnExtremeTest.TabStop = true;
            this.radioBtnExtremeTest.Text = "Extreme Test (7 Days)";
            this.radioBtnExtremeTest.UseVisualStyleBackColor = true;
            // 
            // radioBtnLongTest
            // 
            this.radioBtnLongTest.AutoSize = true;
            this.radioBtnLongTest.Location = new System.Drawing.Point(6, 42);
            this.radioBtnLongTest.Name = "radioBtnLongTest";
            this.radioBtnLongTest.Size = new System.Drawing.Size(125, 17);
            this.radioBtnLongTest.TabIndex = 1;
            this.radioBtnLongTest.TabStop = true;
            this.radioBtnLongTest.Text = "Long Test (24 Hours)";
            this.radioBtnLongTest.UseVisualStyleBackColor = true;
            // 
            // radioBtnShortTest
            // 
            this.radioBtnShortTest.AutoSize = true;
            this.radioBtnShortTest.Location = new System.Drawing.Point(6, 19);
            this.radioBtnShortTest.Name = "radioBtnShortTest";
            this.radioBtnShortTest.Size = new System.Drawing.Size(115, 17);
            this.radioBtnShortTest.TabIndex = 0;
            this.radioBtnShortTest.TabStop = true;
            this.radioBtnShortTest.Text = "Short Test (1 Hour)";
            this.radioBtnShortTest.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 132);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start Test";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 167);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupTestModes);
            this.Controls.Add(this.txtPingInterval);
            this.Controls.Add(this.lblPingInterval);
            this.Controls.Add(this.lblServerAdress);
            this.Controls.Add(this.txtServerAdress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Neasure - Network Measurement";
            this.groupTestModes.ResumeLayout(false);
            this.groupTestModes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerAdress;
        private System.Windows.Forms.Label lblServerAdress;
        private System.Windows.Forms.Label lblPingInterval;
        private System.Windows.Forms.TextBox txtPingInterval;
        private System.Windows.Forms.GroupBox groupTestModes;
        private System.Windows.Forms.RadioButton radioBtnShortTest;
        private System.Windows.Forms.RadioButton radioBtnExtremeTest;
        private System.Windows.Forms.RadioButton radioBtnLongTest;
        private System.Windows.Forms.Button btnStart;
    }
}

