namespace CrmManager
{
    partial class ConfigForm
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
            this.gpSaveSettings = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbAutthDataBaseFile = new System.Windows.Forms.Label();
            this.btnDataBaseDefault = new System.Windows.Forms.Button();
            this.txtDataBasePath = new System.Windows.Forms.TextBox();
            this.btnDataBasePath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAutthPhoneFile = new System.Windows.Forms.Label();
            this.btnRepeatPhoneDefault = new System.Windows.Forms.Button();
            this.txtRepeatPhonePath = new System.Windows.Forms.TextBox();
            this.btnRepeatPhonePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gpSaveSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSaveSettings
            // 
            this.gpSaveSettings.BackColor = System.Drawing.SystemColors.Control;
            this.gpSaveSettings.Controls.Add(this.groupBox2);
            this.gpSaveSettings.Controls.Add(this.groupBox1);
            this.gpSaveSettings.Controls.Add(this.label1);
            this.gpSaveSettings.Location = new System.Drawing.Point(12, 20);
            this.gpSaveSettings.Name = "gpSaveSettings";
            this.gpSaveSettings.Size = new System.Drawing.Size(587, 300);
            this.gpSaveSettings.TabIndex = 0;
            this.gpSaveSettings.TabStop = false;
            this.gpSaveSettings.Text = "Save Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbAutthDataBaseFile);
            this.groupBox2.Controls.Add(this.btnDataBaseDefault);
            this.groupBox2.Controls.Add(this.txtDataBasePath);
            this.groupBox2.Controls.Add(this.btnDataBasePath);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Base Path:";
            // 
            // lbAutthDataBaseFile
            // 
            this.lbAutthDataBaseFile.AutoSize = true;
            this.lbAutthDataBaseFile.Location = new System.Drawing.Point(17, 75);
            this.lbAutthDataBaseFile.Name = "lbAutthDataBaseFile";
            this.lbAutthDataBaseFile.Size = new System.Drawing.Size(0, 13);
            this.lbAutthDataBaseFile.TabIndex = 3;
            // 
            // btnDataBaseDefault
            // 
            this.btnDataBaseDefault.Location = new System.Drawing.Point(421, 67);
            this.btnDataBaseDefault.Name = "btnDataBaseDefault";
            this.btnDataBaseDefault.Size = new System.Drawing.Size(132, 29);
            this.btnDataBaseDefault.TabIndex = 3;
            this.btnDataBaseDefault.Text = "Default &Settings";
            this.btnDataBaseDefault.UseVisualStyleBackColor = true;
            this.btnDataBaseDefault.Click += new System.EventHandler(this.btnDataBaseDefault_Click);
            // 
            // txtDataBasePath
            // 
            this.txtDataBasePath.Location = new System.Drawing.Point(10, 29);
            this.txtDataBasePath.Name = "txtDataBasePath";
            this.txtDataBasePath.Size = new System.Drawing.Size(507, 20);
            this.txtDataBasePath.TabIndex = 1;
            // 
            // btnDataBasePath
            // 
            this.btnDataBasePath.Location = new System.Drawing.Point(523, 29);
            this.btnDataBasePath.Name = "btnDataBasePath";
            this.btnDataBasePath.Size = new System.Drawing.Size(30, 20);
            this.btnDataBasePath.TabIndex = 2;
            this.btnDataBasePath.Text = "...";
            this.btnDataBasePath.UseVisualStyleBackColor = true;
            this.btnDataBasePath.Click += new System.EventHandler(this.btnDataBasePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAutthPhoneFile);
            this.groupBox1.Controls.Add(this.btnRepeatPhoneDefault);
            this.groupBox1.Controls.Add(this.txtRepeatPhonePath);
            this.groupBox1.Controls.Add(this.btnRepeatPhonePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repeat Phone File Path:";
            // 
            // lbAutthPhoneFile
            // 
            this.lbAutthPhoneFile.AutoSize = true;
            this.lbAutthPhoneFile.Location = new System.Drawing.Point(17, 75);
            this.lbAutthPhoneFile.Name = "lbAutthPhoneFile";
            this.lbAutthPhoneFile.Size = new System.Drawing.Size(0, 13);
            this.lbAutthPhoneFile.TabIndex = 4;
            // 
            // btnRepeatPhoneDefault
            // 
            this.btnRepeatPhoneDefault.Location = new System.Drawing.Point(421, 67);
            this.btnRepeatPhoneDefault.Name = "btnRepeatPhoneDefault";
            this.btnRepeatPhoneDefault.Size = new System.Drawing.Size(132, 29);
            this.btnRepeatPhoneDefault.TabIndex = 3;
            this.btnRepeatPhoneDefault.Text = "&Default Settings";
            this.btnRepeatPhoneDefault.UseVisualStyleBackColor = true;
            this.btnRepeatPhoneDefault.Click += new System.EventHandler(this.btnRepeatPhoneDefault_Click);
            // 
            // txtRepeatPhonePath
            // 
            this.txtRepeatPhonePath.Location = new System.Drawing.Point(10, 29);
            this.txtRepeatPhonePath.Name = "txtRepeatPhonePath";
            this.txtRepeatPhonePath.Size = new System.Drawing.Size(507, 20);
            this.txtRepeatPhonePath.TabIndex = 1;
            // 
            // btnRepeatPhonePath
            // 
            this.btnRepeatPhonePath.Location = new System.Drawing.Point(523, 29);
            this.btnRepeatPhonePath.Name = "btnRepeatPhonePath";
            this.btnRepeatPhonePath.Size = new System.Drawing.Size(30, 20);
            this.btnRepeatPhonePath.TabIndex = 2;
            this.btnRepeatPhonePath.Text = "...";
            this.btnRepeatPhonePath.UseVisualStyleBackColor = true;
            this.btnRepeatPhonePath.Click += new System.EventHandler(this.btnRepeatPhonePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 330);
            this.Controls.Add(this.gpSaveSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration Crm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.gpSaveSettings.ResumeLayout(false);
            this.gpSaveSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSaveSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDataBaseDefault;
        private System.Windows.Forms.TextBox txtDataBasePath;
        private System.Windows.Forms.Button btnDataBasePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRepeatPhoneDefault;
        private System.Windows.Forms.TextBox txtRepeatPhonePath;
        private System.Windows.Forms.Button btnRepeatPhonePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAutthDataBaseFile;
        private System.Windows.Forms.Label lbAutthPhoneFile;
    }
}