namespace Neasure
{
    partial class FirebaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirebaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dropdownISP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropdownCountry = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dropdownType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dropdownSpeed = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textPostal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dropdownISP
            // 
            resources.ApplyResources(this.dropdownISP, "dropdownISP");
            this.dropdownISP.FormattingEnabled = true;
            this.dropdownISP.Items.AddRange(new object[] {
            resources.GetString("dropdownISP.Items"),
            resources.GetString("dropdownISP.Items1"),
            resources.GetString("dropdownISP.Items2"),
            resources.GetString("dropdownISP.Items3"),
            resources.GetString("dropdownISP.Items4")});
            this.dropdownISP.Name = "dropdownISP";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dropdownCountry
            // 
            resources.ApplyResources(this.dropdownCountry, "dropdownCountry");
            this.dropdownCountry.FormattingEnabled = true;
            this.dropdownCountry.Items.AddRange(new object[] {
            resources.GetString("dropdownCountry.Items"),
            resources.GetString("dropdownCountry.Items1"),
            resources.GetString("dropdownCountry.Items2")});
            this.dropdownCountry.Name = "dropdownCountry";
            this.dropdownCountry.SelectedIndexChanged += new System.EventHandler(this.dropdownCountry_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textCity
            // 
            resources.ApplyResources(this.textCity, "textCity");
            this.textCity.Name = "textCity";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // dropdownType
            // 
            resources.ApplyResources(this.dropdownType, "dropdownType");
            this.dropdownType.FormattingEnabled = true;
            this.dropdownType.Items.AddRange(new object[] {
            resources.GetString("dropdownType.Items"),
            resources.GetString("dropdownType.Items1"),
            resources.GetString("dropdownType.Items2"),
            resources.GetString("dropdownType.Items3")});
            this.dropdownType.Name = "dropdownType";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // dropdownSpeed
            // 
            resources.ApplyResources(this.dropdownSpeed, "dropdownSpeed");
            this.dropdownSpeed.FormattingEnabled = true;
            this.dropdownSpeed.Items.AddRange(new object[] {
            resources.GetString("dropdownSpeed.Items"),
            resources.GetString("dropdownSpeed.Items1"),
            resources.GetString("dropdownSpeed.Items2"),
            resources.GetString("dropdownSpeed.Items3"),
            resources.GetString("dropdownSpeed.Items4"),
            resources.GetString("dropdownSpeed.Items5"),
            resources.GetString("dropdownSpeed.Items6"),
            resources.GetString("dropdownSpeed.Items7")});
            this.dropdownSpeed.Name = "dropdownSpeed";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textPostal
            // 
            resources.ApplyResources(this.textPostal, "textPostal");
            this.textPostal.Name = "textPostal";
            // 
            // FirebaseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textPostal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dropdownSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dropdownType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dropdownCountry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropdownISP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FirebaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dropdownISP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropdownCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dropdownType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dropdownSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPostal;
    }
}