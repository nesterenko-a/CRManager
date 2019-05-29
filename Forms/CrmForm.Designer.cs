using CrmManager.CrmDB;

namespace CrmManager
{
    partial class CrmForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrmForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbCsvApi = new System.Windows.Forms.TabPage();
            this.btnAddParsingFile = new System.Windows.Forms.Button();
            this.lsUploadInstance = new System.Windows.Forms.ListBox();
            this.btnParsingFile = new System.Windows.Forms.Button();
            this.tbCsvAct = new System.Windows.Forms.TabPage();
            this.waitActualgb = new System.Windows.Forms.GroupBox();
            this.textDefcodeStart = new System.Windows.Forms.MaskedTextBox();
            this.textDefcodeEnd = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.operatorNameCBox = new System.Windows.Forms.ComboBox();
            this.addWaitActbtn = new System.Windows.Forms.Button();
            this.listActualbox = new System.Windows.Forms.ListBox();
            this.tbDataBase = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.descriptionManualtxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.descriptiontxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RepeatActBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSanktYar = new System.Windows.Forms.RadioButton();
            this.rbRobot = new System.Windows.Forms.RadioButton();
            this.rbPeter = new System.Windows.Forms.RadioButton();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSignChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAddNewDefCode = new System.Windows.Forms.ToolStripMenuItem();
            this.timerFileCount = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pgbInstanceCount = new System.Windows.Forms.ToolStripProgressBar();
            this.lblCountPhone = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tbCsvApi.SuspendLayout();
            this.tbCsvAct.SuspendLayout();
            this.waitActualgb.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbDataBase.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbCsvApi);
            this.tabControl1.Controls.Add(this.tbCsvAct);
            this.tabControl1.Controls.Add(this.tbDataBase);
            this.tabControl1.Controls.Add(this.tbLog);
            this.tabControl1.Location = new System.Drawing.Point(12, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 452);
            this.tabControl1.TabIndex = 1;
            // 
            // tbCsvApi
            // 
            this.tbCsvApi.Controls.Add(this.btnAddParsingFile);
            this.tbCsvApi.Controls.Add(this.lsUploadInstance);
            this.tbCsvApi.Controls.Add(this.btnParsingFile);
            this.tbCsvApi.Location = new System.Drawing.Point(4, 22);
            this.tbCsvApi.Name = "tbCsvApi";
            this.tbCsvApi.Padding = new System.Windows.Forms.Padding(3);
            this.tbCsvApi.Size = new System.Drawing.Size(361, 426);
            this.tbCsvApi.TabIndex = 1;
            this.tbCsvApi.Text = "Дозвон";
            this.tbCsvApi.UseVisualStyleBackColor = true;
            // 
            // btnAddParsingFile
            // 
            this.btnAddParsingFile.Location = new System.Drawing.Point(21, 377);
            this.btnAddParsingFile.Name = "btnAddParsingFile";
            this.btnAddParsingFile.Size = new System.Drawing.Size(112, 43);
            this.btnAddParsingFile.TabIndex = 2;
            this.btnAddParsingFile.Text = "Добавить ";
            this.btnAddParsingFile.UseVisualStyleBackColor = true;
            // 
            // lsUploadInstance
            // 
            this.lsUploadInstance.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lsUploadInstance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lsUploadInstance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lsUploadInstance.FormattingEnabled = true;
            this.lsUploadInstance.ItemHeight = 16;
            this.lsUploadInstance.Location = new System.Drawing.Point(21, 10);
            this.lsUploadInstance.Name = "lsUploadInstance";
            this.lsUploadInstance.Size = new System.Drawing.Size(314, 356);
            this.lsUploadInstance.TabIndex = 0;
            // 
            // btnParsingFile
            // 
            this.btnParsingFile.Location = new System.Drawing.Point(139, 377);
            this.btnParsingFile.Name = "btnParsingFile";
            this.btnParsingFile.Size = new System.Drawing.Size(196, 43);
            this.btnParsingFile.TabIndex = 1;
            this.btnParsingFile.Text = "Загрузить &CSV файлы дозвона";
            this.btnParsingFile.UseVisualStyleBackColor = true;
            this.btnParsingFile.Click += new System.EventHandler(this.btnParsingFile_Click);
            // 
            // tbCsvAct
            // 
            this.tbCsvAct.Controls.Add(this.waitActualgb);
            this.tbCsvAct.Location = new System.Drawing.Point(4, 22);
            this.tbCsvAct.Name = "tbCsvAct";
            this.tbCsvAct.Size = new System.Drawing.Size(361, 426);
            this.tbCsvAct.TabIndex = 4;
            this.tbCsvAct.Text = "Актуализация";
            this.tbCsvAct.UseVisualStyleBackColor = true;
            // 
            // waitActualgb
            // 
            this.waitActualgb.Controls.Add(this.textDefcodeStart);
            this.waitActualgb.Controls.Add(this.textDefcodeEnd);
            this.waitActualgb.Controls.Add(this.groupBox3);
            this.waitActualgb.Controls.Add(this.addWaitActbtn);
            this.waitActualgb.Controls.Add(this.listActualbox);
            this.waitActualgb.Location = new System.Drawing.Point(3, 3);
            this.waitActualgb.Name = "waitActualgb";
            this.waitActualgb.Size = new System.Drawing.Size(355, 420);
            this.waitActualgb.TabIndex = 4;
            this.waitActualgb.TabStop = false;
            this.waitActualgb.Text = "Очередь Актаулизации";
            // 
            // textDefcodeStart
            // 
            this.textDefcodeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textDefcodeStart.Location = new System.Drawing.Point(111, 390);
            this.textDefcodeStart.Mask = "000-000";
            this.textDefcodeStart.Name = "textDefcodeStart";
            this.textDefcodeStart.Size = new System.Drawing.Size(73, 27);
            this.textDefcodeStart.TabIndex = 1;
            this.textDefcodeStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDefcodeStart_KeyPress);
            // 
            // textDefcodeEnd
            // 
            this.textDefcodeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textDefcodeEnd.Location = new System.Drawing.Point(190, 390);
            this.textDefcodeEnd.Mask = "000-000";
            this.textDefcodeEnd.Name = "textDefcodeEnd";
            this.textDefcodeEnd.Size = new System.Drawing.Size(72, 27);
            this.textDefcodeEnd.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.operatorNameCBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 46);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Фильтровать по Операторам:";
            // 
            // operatorNameCBox
            // 
            this.operatorNameCBox.FormattingEnabled = true;
            this.operatorNameCBox.Location = new System.Drawing.Point(200, 13);
            this.operatorNameCBox.Name = "operatorNameCBox";
            this.operatorNameCBox.Size = new System.Drawing.Size(137, 21);
            this.operatorNameCBox.TabIndex = 1;
            // 
            // addWaitActbtn
            // 
            this.addWaitActbtn.Location = new System.Drawing.Point(268, 390);
            this.addWaitActbtn.Name = "addWaitActbtn";
            this.addWaitActbtn.Size = new System.Drawing.Size(81, 27);
            this.addWaitActbtn.TabIndex = 3;
            this.addWaitActbtn.Text = "В очередь >>";
            this.addWaitActbtn.UseVisualStyleBackColor = true;
            this.addWaitActbtn.Click += new System.EventHandler(this.addWaitActbtn_Click);
            // 
            // listActualbox
            // 
            this.listActualbox.FormattingEnabled = true;
            this.listActualbox.Location = new System.Drawing.Point(6, 69);
            this.listActualbox.Name = "listActualbox";
            this.listActualbox.Size = new System.Drawing.Size(343, 303);
            this.listActualbox.TabIndex = 0;
            this.listActualbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listActualbox_KeyPress);
            // 
            // tbDataBase
            // 
            this.tbDataBase.Controls.Add(this.groupBox2);
            this.tbDataBase.Controls.Add(this.groupBox1);
            this.tbDataBase.Location = new System.Drawing.Point(4, 22);
            this.tbDataBase.Name = "tbDataBase";
            this.tbDataBase.Padding = new System.Windows.Forms.Padding(3);
            this.tbDataBase.Size = new System.Drawing.Size(361, 426);
            this.tbDataBase.TabIndex = 2;
            this.tbDataBase.Text = "Доп. Настройки";
            this.tbDataBase.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.descriptionManualtxtbox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.descriptiontxtbox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RepeatActBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 127);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Актуализация";
            // 
            // descriptionManualtxtbox
            // 
            this.descriptionManualtxtbox.Location = new System.Drawing.Point(135, 98);
            this.descriptionManualtxtbox.Name = "descriptionManualtxtbox";
            this.descriptionManualtxtbox.Size = new System.Drawing.Size(208, 20);
            this.descriptionManualtxtbox.TabIndex = 7;
            this.descriptionManualtxtbox.Text = "Ручное";
            this.descriptionManualtxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Примечание руч.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Примечание авт.:";
            // 
            // descriptiontxtbox
            // 
            this.descriptiontxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptiontxtbox.Location = new System.Drawing.Point(135, 61);
            this.descriptiontxtbox.Name = "descriptiontxtbox";
            this.descriptiontxtbox.Size = new System.Drawing.Size(208, 20);
            this.descriptiontxtbox.TabIndex = 5;
            this.descriptiontxtbox.Text = "Автоматическое";
            this.descriptiontxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "повторов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Отправлять на актуализацию после:";
            // 
            // RepeatActBox
            // 
            this.RepeatActBox.FormattingEnabled = true;
            this.RepeatActBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.RepeatActBox.Location = new System.Drawing.Point(248, 28);
            this.RepeatActBox.Name = "RepeatActBox";
            this.RepeatActBox.Size = new System.Drawing.Size(35, 21);
            this.RepeatActBox.TabIndex = 0;
            this.RepeatActBox.Text = "8";
            this.RepeatActBox.SelectedValueChanged += new System.EventHandler(this.RepeatActBox_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSanktYar);
            this.groupBox1.Controls.Add(this.rbRobot);
            this.groupBox1.Controls.Add(this.rbPeter);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проект Санкт-Петербург";
            // 
            // rbSanktYar
            // 
            this.rbSanktYar.AutoSize = true;
            this.rbSanktYar.Location = new System.Drawing.Point(238, 19);
            this.rbSanktYar.Name = "rbSanktYar";
            this.rbSanktYar.Size = new System.Drawing.Size(114, 17);
            this.rbSanktYar.TabIndex = 2;
            this.rbSanktYar.TabStop = true;
            this.rbSanktYar.Text = "Санкт-Ярославль";
            this.rbSanktYar.UseVisualStyleBackColor = true;
            // 
            // rbRobot
            // 
            this.rbRobot.AutoSize = true;
            this.rbRobot.Location = new System.Drawing.Point(145, 19);
            this.rbRobot.Name = "rbRobot";
            this.rbRobot.Size = new System.Drawing.Size(47, 17);
            this.rbRobot.TabIndex = 1;
            this.rbRobot.Text = "СПБ";
            this.rbRobot.UseVisualStyleBackColor = true;
            // 
            // rbPeter
            // 
            this.rbPeter.AutoSize = true;
            this.rbPeter.Checked = true;
            this.rbPeter.Location = new System.Drawing.Point(15, 19);
            this.rbPeter.Name = "rbPeter";
            this.rbPeter.Size = new System.Drawing.Size(78, 17);
            this.rbPeter.TabIndex = 0;
            this.rbPeter.TabStop = true;
            this.rbPeter.Text = "Петербург";
            this.rbPeter.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.label1);
            this.tbLog.Controls.Add(this.txtLog);
            this.tbLog.Location = new System.Drawing.Point(4, 22);
            this.tbLog.Name = "tbLog";
            this.tbLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbLog.Size = new System.Drawing.Size(361, 426);
            this.tbLog.TabIndex = 3;
            this.tbLog.Text = "Log";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(17, 41);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(327, 338);
            this.txtLog.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSignOut,
            this.mnSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(389, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnSignOut
            // 
            this.mnSignOut.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnSignChange,
            this.mnExit});
            this.mnSignOut.Name = "mnSignOut";
            this.mnSignOut.Size = new System.Drawing.Size(53, 20);
            this.mnSignOut.Text = "&Меню";
            // 
            // mnSignChange
            // 
            this.mnSignChange.Image = global::CrmManager.Properties.Resources.unlock__access__key__password_512;
            this.mnSignChange.Name = "mnSignChange";
            this.mnSignChange.Size = new System.Drawing.Size(154, 22);
            this.mnSignChange.Text = "Л&огин / &Выйти";
            this.mnSignChange.Click += new System.EventHandler(this.mnSignChange_Click);
            // 
            // mnExit
            // 
            this.mnExit.Image = global::CrmManager.Properties.Resources.sm_6_600;
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(154, 22);
            this.mnExit.Text = "З&акрыть";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnSettings
            // 
            this.mnSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnConfig,
            this.mnAddNewDefCode});
            this.mnSettings.Name = "mnSettings";
            this.mnSettings.Size = new System.Drawing.Size(79, 20);
            this.mnSettings.Text = "&Настройки";
            // 
            // mnConfig
            // 
            this.mnConfig.Image = global::CrmManager.Properties.Resources.shesterenka;
            this.mnConfig.Name = "mnConfig";
            this.mnConfig.Size = new System.Drawing.Size(172, 22);
            this.mnConfig.Text = "&Конфигурация";
            this.mnConfig.Click += new System.EventHandler(this.mnConfig_Click);
            // 
            // mnAddNewDefCode
            // 
            this.mnAddNewDefCode.Image = global::CrmManager.Properties.Resources._84192_plus_512x512;
            this.mnAddNewDefCode.Name = "mnAddNewDefCode";
            this.mnAddNewDefCode.Size = new System.Drawing.Size(172, 22);
            this.mnAddNewDefCode.Text = "&Добавить ДефКод";
            this.mnAddNewDefCode.Click += new System.EventHandler(this.mnAddNewDefCode_Click);
            // 
            // timerFileCount
            // 
            this.timerFileCount.Interval = 1000;
            this.timerFileCount.Tick += new System.EventHandler(this.timerFileCount_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbInstanceCount,
            this.lblCountPhone});
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(389, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pgbInstanceCount
            // 
            this.pgbInstanceCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pgbInstanceCount.Name = "pgbInstanceCount";
            this.pgbInstanceCount.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pgbInstanceCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgbInstanceCount.Size = new System.Drawing.Size(270, 16);
            // 
            // lblCountPhone
            // 
            this.lblCountPhone.Name = "lblCountPhone";
            this.lblCountPhone.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblCountPhone.Size = new System.Drawing.Size(102, 17);
            this.lblCountPhone.Spring = true;
            this.lblCountPhone.Text = "0";
            // 
            // CrmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 521);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CrmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRMSplit";
            this.Load += new System.EventHandler(this.CrmForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbCsvApi.ResumeLayout(false);
            this.tbCsvAct.ResumeLayout(false);
            this.waitActualgb.ResumeLayout(false);
            this.waitActualgb.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbDataBase.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbLog.ResumeLayout(false);
            this.tbLog.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbCsvApi;
        private System.Windows.Forms.Button btnParsingFile;
        private System.Windows.Forms.ListBox lsUploadInstance;
        private System.Windows.Forms.TabPage tbDataBase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnSignOut;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem mnSignChange;
        private System.Windows.Forms.ToolStripMenuItem mnSettings;
        private System.Windows.Forms.ToolStripMenuItem mnConfig;
        private System.Windows.Forms.TabPage tbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem mnAddNewDefCode;
        private System.Windows.Forms.Timer timerFileCount;
        private System.Windows.Forms.RadioButton rbRobot;
        private System.Windows.Forms.RadioButton rbPeter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox RepeatActBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox waitActualgb;
        private System.Windows.Forms.ListBox listActualbox;
        private System.Windows.Forms.Button addWaitActbtn;
        private System.Windows.Forms.TextBox descriptiontxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox descriptionManualtxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tbCsvAct;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox operatorNameCBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pgbInstanceCount;
        private System.Windows.Forms.ToolStripStatusLabel lblCountPhone;
        private System.Windows.Forms.Button btnAddParsingFile;
        private System.Windows.Forms.RadioButton rbSanktYar;
        private System.Windows.Forms.MaskedTextBox textDefcodeStart;
        private System.Windows.Forms.MaskedTextBox textDefcodeEnd;
    }
}

