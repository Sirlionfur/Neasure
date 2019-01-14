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
            this.groupTestModes = new System.Windows.Forms.GroupBox();
            this.radioBtnDebug = new System.Windows.Forms.RadioButton();
            this.radioBtnExtremeTest = new System.Windows.Forms.RadioButton();
            this.radioBtnLongTest = new System.Windows.Forms.RadioButton();
            this.radioBtnShortTest = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupTestModes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupTestModes);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.groupTestModes.ResumeLayout(false);
            this.groupTestModes.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupTestModes;
        private System.Windows.Forms.RadioButton radioBtnShortTest;
        private System.Windows.Forms.RadioButton radioBtnExtremeTest;
        private System.Windows.Forms.RadioButton radioBtnLongTest;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton radioBtnDebug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

