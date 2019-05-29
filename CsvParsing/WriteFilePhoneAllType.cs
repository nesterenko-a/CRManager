using System;
using System.IO;
using System.Windows.Forms;
using CrmManager.CsvParsing.customList;

namespace CrmManager.CsvParsing
{
    class WriteFilePhoneAllType
    {
        private string file;
        private string city;
        private string sotOperator;
        private string defCode;
        private FileName.TypeRu typeNameFile;

        private GetPhoneList instancePhone;
        private AbstractPhone abstractPhone;

        /// <summary>
        /// Разделение на Файлы данных csv актуализации
        /// </summary>
        /// <param name="defkod">дефкод</param>
        /// <param name="file">путь к csv файлу</param>
        /// <param name="sot_operator">имя оператора</param>
        /// <param name="name">Ответ, Не ответ, Занято</param>
        /// <param name="file_body">Данные листа</param>
        public   WriteFilePhoneAllType (GetPhoneList instancePhone, AbstractPhone abstractPhone)
        {
            this.abstractPhone = abstractPhone;
            this.instancePhone = instancePhone;
            this.file = abstractPhone.PathFile; // files[0];
            this.city = instancePhone.resultDefCode.CityName;
            this.sotOperator = instancePhone.resultDefCode.OperatorName;
            this.defCode = instancePhone.resultDefCode.DefCodeName;
            this.typeNameFile = abstractPhone.TypeFile_RU;

            if (Write()) Delete();
           
        }

        public bool Write()
        {
            string pathToFile = Path.GetDirectoryName(file) + "\\" + city + "\\" + sotOperator + "\\" + defCode;
            Directory.CreateDirectory(pathToFile);
            int countrepeatphone = default;
            string directory = pathToFile + "\\" + defCode + "_" + typeNameFile.ToString() + "_" + RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(file), LanguageClass.Language.RU, out countrepeatphone) + ".txt"; 
            
            switch(typeNameFile)
            {
                case FileName.TypeRu.Ответ:
                    if (!Writings(instancePhone.answer, directory)) return false; break;
                case FileName.TypeRu.Не_Ответ:
                    if (!Writings(instancePhone.no_answer, directory)) return false; break;
                case FileName.TypeRu.ПАС:
                    if (!Writings(instancePhone.skipped, directory)) return false; break;
            }
            return true;
        }
        private void Delete()
        {
            File.Delete(abstractPhone.PathFile);
        }

        private void DeleteAllInstance()
        {
            foreach (var result in instancePhone.files)
                File.Delete(result);
        }

        private bool Writings(AbstractPhone abstractPhone, string directory)
        {
            try
            {

                StreamWriter sw = new StreamWriter(directory);
                foreach (var result in abstractPhone.phone)
                {
                    sw.WriteLine(result);
                }
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
