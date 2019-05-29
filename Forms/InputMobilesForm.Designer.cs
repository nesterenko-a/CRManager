namespace CrmManager.Forms
{
    partial class InputMobilesForm
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
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtDefCodeName = new System.Windows.Forms.MaskedTextBox();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnAddOperator = new System.Windows.Forms.Button();
            this.gbSingle = new System.Windows.Forms.GroupBox();
            this.gbDiapozone = new System.Windows.Forms.GroupBox();
            this.txtDefCodeNameEnd = new System.Windows.Forms.MaskedTextBox();
            this.txtDefCodeNameStart = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmitDiapozone = new System.Windows.Forms.Button();
            this.gbSingle.SuspendLayout();
            this.gbDiapozone.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(131, 18);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(216, 21);
            this.cmbCity.TabIndex = 0;
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(131, 52);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(216, 21);
            this.cmbOperator.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(6, 58);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(89, 32);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "&Сохранить >";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtDefCodeName
            // 
            this.txtDefCodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDefCodeName.Location = new System.Drawing.Point(6, 19);
            this.txtDefCodeName.Mask = "000-999";
            this.txtDefCodeName.Name = "txtDefCodeName";
            this.txtDefCodeName.Size = new System.Drawing.Size(89, 31);
            this.txtDefCodeName.TabIndex = 2;
            // 
            // btnAddCity
            // 
            this.btnAddCity.Location = new System.Drawing.Point(353, 18);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(27, 21);
            this.btnAddCity.TabIndex = 4;
            this.btnAddCity.Text = "+";
            this.btnAddCity.UseVisualStyleBackColor = true;
            // 
            // btnAddOperator
            // 
            this.btnAddOperator.Location = new System.Drawing.Point(353, 52);
            this.btnAddOperator.Name = "btnAddOperator";
            this.btnAddOperator.Size = new System.Drawing.Size(27, 21);
            this.btnAddOperator.TabIndex = 5;
            this.btnAddOperator.Text = "+";
            this.btnAddOperator.UseVisualStyleBackColor = true;
            // 
            // gbSingle
            // 
            this.gbSingle.Controls.Add(this.btnSubmit);
            this.gbSingle.Controls.Add(this.txtDefCodeName);
            this.gbSingle.Location = new System.Drawing.Point(9, 89);
            this.gbSingle.Name = "gbSingle";
            this.gbSingle.Size = new System.Drawing.Size(108, 100);
            this.gbSingle.TabIndex = 6;
            this.gbSingle.TabStop = false;
            // 
            // gbDiapozone
            // 
            this.gbDiapozone.Controls.Add(this.btnSubmitDiapozone);
            this.gbDiapozone.Controls.Add(this.txtDefCodeNameEnd);
            this.gbDiapozone.Controls.Add(this.txtDefCodeNameStart);
            this.gbDiapozone.Location = new System.Drawing.Point(131, 89);
            this.gbDiapozone.Name = "gbDiapozone";
            this.gbDiapozone.Size = new System.Drawing.Size(250, 100);
            this.gbDiapozone.TabIndex = 7;
            this.gbDiapozone.TabStop = false;
            // 
            // txtDefCodeNameEnd
            // 
            this.txtDefCodeNameEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDefCodeNameEnd.Location = new System.Drawing.Point(134, 19);
            this.txtDefCodeNameEnd.Mask = "000-999";
            this.txtDefCodeNameEnd.Name = "txtDefCodeNameEnd";
            this.txtDefCodeNameEnd.Size = new System.Drawing.Size(89, 31);
            this.txtDefCodeNameEnd.TabIndex = 2;
            // 
            // txtDefCodeNameStart
            // 
            this.txtDefCodeNameStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDefCodeNameStart.Location = new System.Drawing.Point(25, 19);
            this.txtDefCodeNameStart.Mask = "000-999";
            this.txtDefCodeNameStart.Name = "txtDefCodeNameStart";
            this.txtDefCodeNameStart.Size = new System.Drawing.Size(89, 31);
            this.txtDefCodeNameStart.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Проект:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сотовый оператор:";
            // 
            // btnSubmitDiapozone
            // 
            this.btnSubmitDiapozone.Location = new System.Drawing.Point(25, 58);
            this.btnSubmitDiapozone.Name = "btnSubmitDiapozone";
            this.btnSubmitDiapozone.Size = new System.Drawing.Size(198, 32);
            this.btnSubmitDiapozone.TabIndex = 3;
            this.btnSubmitDiapozone.Text = "Сохранить >";
            this.btnSubmitDiapozone.UseVisualStyleBackColor = true;
            this.btnSubmitDiapozone.Click += new System.EventHandler(this.btnSubmitDiapozone_Click);
            // 
            // InputMobilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 191);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbDiapozone);
            this.Controls.Add(this.gbSingle);
            this.Controls.Add(this.btnAddOperator);
            this.Controls.Add(this.btnAddCity);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.cmbCity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputMobilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить";
            this.gbSingle.ResumeLayout(false);
            this.gbSingle.PerformLayout();
            this.gbDiapozone.ResumeLayout(false);
            this.gbDiapozone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.MaskedTextBox txtDefCodeName;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnAddOperator;
        private System.Windows.Forms.GroupBox gbSingle;
        private System.Windows.Forms.GroupBox gbDiapozone;
        private System.Windows.Forms.MaskedTextBox txtDefCodeNameEnd;
        private System.Windows.Forms.MaskedTextBox txtDefCodeNameStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmitDiapozone;
    }
}