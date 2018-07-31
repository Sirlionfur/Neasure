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
            this.groupTestModes = new System.Windows.Forms.GroupBox();
            this.radioBtnDebug = new System.Windows.Forms.RadioButton();
            this.radioBtnExtremeTest = new System.Windows.Forms.RadioButton();
            this.radioBtnLongTest = new System.Windows.Forms.RadioButton();
            this.radioBtnShortTest = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnInterval1Sec = new System.Windows.Forms.RadioButton();
            this.groupTestModes.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // groupTestModes
            // 
            this.groupTestModes.Controls.Add(this.radioBtnDebug);
            this.groupTestModes.Controls.Add(this.radioBtnExtremeTest);
            this.groupTestModes.Controls.Add(this.radioBtnLongTest);
            this.groupTestModes.Controls.Add(this.radioBtnShortTest);
            resources.ApplyResources(this.groupTestModes, "groupTestModes");
            this.groupTestModes.Name = "groupTestModes";
            this.groupTestModes.TabStop = false;
            // 
            // radioBtnDebug
            // 
            resources.ApplyResources(this.radioBtnDebug, "radioBtnDebug");
            this.radioBtnDebug.Name = "radioBtnDebug";
            this.radioBtnDebug.TabStop = true;
            this.radioBtnDebug.UseVisualStyleBackColor = true;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnInterval1Sec);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // radioBtnInterval1Sec
            // 
            resources.ApplyResources(this.radioBtnInterval1Sec, "radioBtnInterval1Sec");
            this.radioBtnInterval1Sec.Name = "radioBtnInterval1Sec";
            this.radioBtnInterval1Sec.TabStop = true;
            this.radioBtnInterval1Sec.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupTestModes);
            this.Controls.Add(this.lblServerAdress);
            this.Controls.Add(this.txtServerAdress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.groupTestModes.ResumeLayout(false);
            this.groupTestModes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerAdress;
        private System.Windows.Forms.Label lblServerAdress;
        private System.Windows.Forms.GroupBox groupTestModes;
        private System.Windows.Forms.RadioButton radioBtnShortTest;
        private System.Windows.Forms.RadioButton radioBtnExtremeTest;
        private System.Windows.Forms.RadioButton radioBtnLongTest;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton radioBtnDebug;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnInterval1Sec;
    }
}

