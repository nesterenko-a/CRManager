using System.IO;
using System.Text;
using System.Windows.Forms;
using CrmManager.CsvParsing;

namespace CrmManager
{
    public class OpenFile
    {
        OpenFileDialog open;
        private string name;
        public string[] PathNames { get; set; }
        public DialogResult dialogResult { get; set; }

        public string PathName
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private TypeFileSave.TypeFiles type_file;

        private string TypeFilter(TypeFileSave.TypeFiles typeFiles)
        {
            switch(typeFiles)
            {
                case TypeFileSave.TypeFiles.CsvFile: return "CSV files(*.csv)|*.csv";
                case TypeFileSave.TypeFiles.dbConnectionPath: return "DB files(*.db)|*.db";
                case TypeFileSave.TypeFiles.PhoneNumber: return "TXT files(*.txt)|*.txt";
                default: return "All files(*.*)|*.*";
            }
        }

        public OpenFile(bool multiselect, string default_path, TypeFileSave.TypeFiles type_file)
        {
            this.type_file = type_file;

            if (File.Exists(default_path))
            {
                PathName = default_path;
            }
            else
            {
                open = new OpenFileDialog();
                open.Multiselect = multiselect;
                open.Filter = TypeFilter(type_file);
                dialogResult = open.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    #region Save settings paths: PhoneNumber, dbConnection, CsvFile
                    if (type_file == TypeFileSave.TypeFiles.PhoneNumber)
                    {
                        PathName = open.FileName;
                        PathSettings.Default.path_phone_number = PathName;
                        PathSettings.Default.Save();
                    }
                    if (type_file == TypeFileSave.TypeFiles.dbConnectionPath)
                    {
                        PathName = open.FileName;
                        PathSettings.Default.dbConnectionName = PathName;
                        PathSettings.Default.Save();
                    }
                    if (type_file == TypeFileSave.TypeFiles.CsvFile)
                    {
                        PathNames = open.FileNames;
                    }
                    #endregion
                }
            }
        }      

        public static void GreateFile(TypeFileSave.TypeFiles typeFiles)
        {
            switch (typeFiles)
            {
                case TypeFileSave.TypeFiles.PhoneNumber:
                    PathSettings.Default.path_phone_number = SettingFilePath.phoneNumberPath;
                    CreatePhoneEmpty("", TypeFileSave.TypeFiles.PhoneNumber);
                    break;
              
                case TypeFileSave.TypeFiles.dbConnectionPath:
                    PathSettings.Default.dbConnectionName = SettingFilePath.dbConnectionName;
                    break;

                default:
                    PathSettings.Default.Error = "Error path name";
                    break;
            }

            PathSettings.Default.Save();
        }

        private static void CreatePhoneEmpty(string bodyFile, TypeFileSave.TypeFiles typeFiles)
        {
            Directory.CreateDirectory(SettingFilePath.path_config); //Если путь не существует то создаем директорию config
            switch (typeFiles)
            {
                case TypeFileSave.TypeFiles.PhoneNumber:
                    if (!File.Exists(SettingFilePath.phoneNumberPath)) //Если файл не существует то создаем его в директории config и заполняем  
                    {
                        using (FileStream sw = new FileStream(SettingFilePath.phoneNumberPath, FileMode.OpenOrCreate))
                        {
                            byte[] array = Encoding.Default.GetBytes(bodyFile);
                            sw.Write(array, 0, array.Length);
                            sw.Close();
                        }
                    }
                    break;

                case TypeFileSave.TypeFiles.dbConnectionPath:
                    ///Текст
                    break;
            }
        }
    }
}
       
