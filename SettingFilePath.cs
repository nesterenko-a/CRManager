using CrmManager.CsvParsing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CrmManager
{
    public static class SettingFilePath
    {
        #region DefaultPathFile
        public static string phoneNumberPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\config\\phone_numbers.txt";
        public static string path_config = Path.GetDirectoryName(Application.ExecutablePath) + "\\config";
        public static string dbConnectionName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config\\" + "CRMSQLiteDB.db";
        #endregion
       

        public static string[] cutCodes = PathSettings.Default.cutCodes.Split(','); // 77,99 cut nambers
        public static string csrf_token = null; //как то надо продумтаь сохранение токена чтобы 100 раз не авторизовываться.

        public static string defkod = "no";
        public static List<string> phoneRepeatList = OpenPhoneNumber.ListPhone(PathSettings.Default.path_phone_number);

        public static void FileExistMethod()
        {
            if (!File.Exists(PathSettings.Default.path_phone_number) || !File.Exists(PathSettings.Default.dbConnectionName))
            {
                var result = MessageBox.Show("Not found required configuration files. \n Menu: Settings\\Configuration.", "Change congiguration", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    ConfigForm uniqueConfigForm = SingleForm.ConfigFormInstance();
                    uniqueConfigForm.ShowDialog();
                }
            }
        }
    }
   
}
