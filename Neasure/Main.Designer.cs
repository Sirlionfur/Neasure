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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            resources.ApplyResources(this.txtServerAdress, "txtServerAdress");
            this.txtServerAdress.Name = "txtServerAdress";
            // 
            // lblServerAdress
            // 
            resources.ApplyResources(this.lblServerAdress, "lblServerAdress");
            this.lblServerAdress.Name = "lblServerAdress";
            // 
            // lblPingInterval
            // 
            resources.ApplyResources(this.lblPingInterval, "lblPingInterval");
            this.lblPingInterval.Name = "lblPingInterval";
            // 
            // txtPingInterval
            // 
            resources.ApplyResources(this.txtPingInterval, "txtPingInterval");
            this.txtPingInterval.Name = "txtPingInterval";
            // 
            // groupTestModes
            // 
            resources.ApplyResources(this.groupTestModes, "groupTestModes");
            this.groupTestModes.Controls.Add(this.radioBtnExtremeTest);
            this.groupTestModes.Controls.Add(this.radioBtnLongTest);
            this.groupTestModes.Controls.Add(this.radioBtnShortTest);
            this.groupTestModes.Name = "groupTestModes";
            this.groupTestModes.TabStop = false;
            // 
            // radioBtnExtremeTest
            // 
            resources.ApplyResources(this.radioBtnExtremeTest, "radioBtnExtremeTest");
            this.radioBtnExtremeTest.Name = "radioBtnExtremeTest";
            this.radioBtnExtremeTest.TabStop = true;
            this.radioBtnExtremeTest.UseVisualStyleBackColor = true;
            // 
            // radioBtnLongTest
            // 
            resources.ApplyResources(this.radioBtnLongTest, "radioBtnLongTest");
            this.radioBtnLongTest.Name = "radioBtnLongTest";
            this.radioBtnLongTest.TabStop = true;
            this.radioBtnLongTest.UseVisualStyleBackColor = true;
            // 
            // radioBtnShortTest
            // 
            resources.ApplyResources(this.radioBtnShortTest, "radioBtnShortTest");
            this.radioBtnShortTest.Name = "radioBtnShortTest";
            this.radioBtnShortTest.TabStop = true;
            this.radioBtnShortTest.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupTestModes);
            this.Controls.Add(this.txtPingInterval);
            this.Controls.Add(this.lblPingInterval);
            this.Controls.Add(this.lblServerAdress);
            this.Controls.Add(this.txtServerAdress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
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

