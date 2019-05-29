using CrmManager.CsvParsing;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CrmManager
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            FormClosed += new FormClosedEventHandler((x, ex) => SingleForm.uniqueConfigForm = null);
          
            FileExist(TypeFileSave.TypeFiles.PhoneNumber, EnumYesNo.YesNo.No);
            FileExist(TypeFileSave.TypeFiles.dbConnectionPath, EnumYesNo.YesNo.No);
        }

        private void AuthLabelFile(TypeFileSave.TypeFiles typeFiles, EnumYesNo.YesNo auth)
        {
            #region AuthFileYes
            if (auth == EnumYesNo.YesNo.Yes)
                switch (typeFiles)
                { 
                    case TypeFileSave.TypeFiles.PhoneNumber:
                        lbAutthPhoneFile.Text = "File Except! Change directory!";
                        txtRepeatPhonePath.BackColor = Color.Red;
                        break;

                    case TypeFileSave.TypeFiles.dbConnectionPath:
                        lbAutthDataBaseFile.Text = "File Except! Change directory!";
                        txtDataBasePath.BackColor = Color.Red;
                        break;
                }
            #endregion

            #region AuthFileNo
            else if (auth == EnumYesNo.YesNo.No)
            {
                switch (typeFiles)
                {
                    case TypeFileSave.TypeFiles.PhoneNumber:
                        lbAutthPhoneFile.Text = "";
                        txtRepeatPhonePath.BackColor = Color.White;
                        txtRepeatPhonePath.Text = PathSettings.Default.path_phone_number;
                        break;

                    case TypeFileSave.TypeFiles.dbConnectionPath:
                        lbAutthDataBaseFile.Text = "";
                        txtDataBasePath.Text = PathSettings.Default.dbConnectionName;
                        txtRepeatPhonePath.BackColor = Color.White;
                        break;
                }
            }
            #endregion
        }

        private void FileExist(TypeFileSave.TypeFiles typeFiles, EnumYesNo.YesNo create)
        {
            switch(typeFiles)
            {
                #region Проверка на существование файла Телефоных Повторов
                case TypeFileSave.TypeFiles.PhoneNumber:
                    if (create == EnumYesNo.YesNo.Yes) PathSettings.Default.path_phone_number = null;
                    if (!File.Exists(PathSettings.Default.path_phone_number))
                    {
                        AuthLabelFile(TypeFileSave.TypeFiles.PhoneNumber, EnumYesNo.YesNo.Yes);

                        OpenFile openFile = new OpenFile(true, null, TypeFileSave.TypeFiles.PhoneNumber);
                        if (openFile.dialogResult == DialogResult.OK)
                            txtRepeatPhonePath.Text = PathSettings.Default.path_phone_number;
                        else
                            txtRepeatPhonePath.Text = "";
                    }
                    else AuthLabelFile(TypeFileSave.TypeFiles.PhoneNumber, EnumYesNo.YesNo.No);
                 break;

                #endregion

                #region Проверка на существование базы данных
                case TypeFileSave.TypeFiles.dbConnectionPath:
                    if (create == EnumYesNo.YesNo.Yes) PathSettings.Default.dbConnectionName = null;
                    if (!File.Exists(PathSettings.Default.dbConnectionName))
                    {
                        AuthLabelFile(TypeFileSave.TypeFiles.dbConnectionPath, EnumYesNo.YesNo.Yes);

                        OpenFile openFile = new OpenFile(false, null, TypeFileSave.TypeFiles.dbConnectionPath);
                        txtDataBasePath.Text = PathSettings.Default.dbConnectionName;
                    }
                    else AuthLabelFile(TypeFileSave.TypeFiles.dbConnectionPath, EnumYesNo.YesNo.No);
                    break;
                #endregion

                default: break;
            }
        }

        private void btnRepeatPhoneDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to reset the default settings and create empty phone file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtRepeatPhonePath.Text = SettingFilePath.phoneNumberPath;
                OpenFile.GreateFile(TypeFileSave.TypeFiles.PhoneNumber);
                AuthLabelFile(TypeFileSave.TypeFiles.PhoneNumber, EnumYesNo.YesNo.No);
            }
        }

        private void btnDataBaseDefault_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to reset the default settings and create empty Data Base file?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtDataBasePath.Text = SettingFilePath.dbConnectionName;
                OpenFile.GreateFile(TypeFileSave.TypeFiles.dbConnectionPath); //Вызов создавалки по умолчанию
                AuthLabelFile(TypeFileSave.TypeFiles.dbConnectionPath, EnumYesNo.YesNo.No);
            }
        }

        private void btnRepeatPhonePath_Click(object sender, EventArgs e)
        {
            OpenFile open = new OpenFile(false,  null, TypeFileSave.TypeFiles.PhoneNumber);
            txtRepeatPhonePath.Text = PathSettings.Default.path_phone_number;
        }

        private void btnDataBasePath_Click(object sender, EventArgs e)
        {
            OpenFile open = new OpenFile(false, null, TypeFileSave.TypeFiles.dbConnectionPath);
            txtDataBasePath.Text = PathSettings.Default.dbConnectionName;
        }
    }
}
