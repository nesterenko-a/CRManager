namespace CrmManager
{
    partial class LoginForm
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
            this.grbLoginRequest = new System.Windows.Forms.GroupBox();
            this.cmBoxServerName = new System.Windows.Forms.ComboBox();
            this.lbServer = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.ckRemember = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbLoginRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLoginRequest
            // 
            this.grbLoginRequest.Controls.Add(this.cmBoxServerName);
            this.grbLoginRequest.Controls.Add(this.lbServer);
            this.grbLoginRequest.Controls.Add(this.btnLogIn);
            this.grbLoginRequest.Controls.Add(this.ckRemember);
            this.grbLoginRequest.Controls.Add(this.txtPassword);
            this.grbLoginRequest.Controls.Add(this.txtLogin);
            this.grbLoginRequest.Controls.Add(this.label2);
            this.grbLoginRequest.Controls.Add(this.label1);
            this.grbLoginRequest.Location = new System.Drawing.Point(12, 16);
            this.grbLoginRequest.Name = "grbLoginRequest";
            this.grbLoginRequest.Size = new System.Drawing.Size(301, 271);
            this.grbLoginRequest.TabIndex = 0;
            this.grbLoginRequest.TabStop = false;
            this.grbLoginRequest.Text = "Login in CRM";
            // 
            // cmBoxServerName
            // 
            this.cmBoxServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxServerName.FormattingEnabled = true;
            this.cmBoxServerName.Items.AddRange(new object[] {
            "https://crmyar.bbclinics.pro",
            "https://crmlat.bbclinics.pro",
            "https://yar.mdcnt.ru"});
            this.cmBoxServerName.Location = new System.Drawing.Point(63, 54);
            this.cmBoxServerName.Name = "cmBoxServerName";
            this.cmBoxServerName.Size = new System.Drawing.Size(174, 21);
            this.cmBoxServerName.TabIndex = 1;
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(62, 33);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(73, 13);
            this.lbServer.TabIndex = 0;
            this.lbServer.Text = "&ServerAdress:";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(99, 195);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(94, 37);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "&Sign In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // ckRemember
            // 
            this.ckRemember.AutoSize = true;
            this.ckRemember.Location = new System.Drawing.Point(64, 172);
            this.ckRemember.Name = "ckRemember";
            this.ckRemember.Size = new System.Drawing.Size(173, 17);
            this.ckRemember.TabIndex = 4;
            this.ckRemember.Text = "&Remembe Login and Password";
            this.ckRemember.UseVisualStyleBackColor = true;
            this.ckRemember.CheckedChanged += new System.EventHandler(this.ckRemember_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(63, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(174, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(63, 99);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(174, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Login:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(142, 300);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(45, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log Out";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 327);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 259);
            this.textBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 11);
            this.panel1.TabIndex = 2;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 327);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.grbLoginRequest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.grbLoginRequest.ResumeLayout(false);
            this.grbLoginRequest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLoginRequest;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckRemember;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmBoxServerName;
        private System.Windows.Forms.Label lbServer;
    }
}