using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CrmManager.CsvParsing;
using CrmManager;
using CrmManager.CsvParsing.customList;
using CrmManager.CrmDB;
using CrmManager.CrmDB.QueryDB;
using CrmManager.Forms;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CsvParsingManager.CsvParsing
{
    class CsvApiManager
    {     
        private Logger logger;
        private AnswerClass answer = null;
        private NotAnswerClass not_answer = null;
        private SkippedClass skipped = null;
        private List<string> open_phone_number;    
        public GetPhoneList actual_base;
        public Logic logicDB;
        private string defFileCode = null;

        private InputMobilesForm inputMobilesForm;


        public CsvApiManager(Logger logger, Logic logicDB)
        {
            this.logger = logger;
            this.logicDB = logicDB;
            this.logicDB.SetLogger(logger); // наверное не нужно

            actual_base = new GetPhoneList();

            answer = new AnswerClass(logicDB);
            not_answer = new NotAnswerClass(logicDB);
            skipped = new SkippedClass(logicDB);

            SettingFilePath.FileExistMethod();
            open_phone_number = SettingFilePath.phoneRepeatList;
            if (open_phone_number == null) return;
        }

        private  void CreateFormInputMobile()
        {
            inputMobilesForm = new InputMobilesForm(Logic.GetCityList(), Logic.GetOperatorList(), SettingFilePath.defkod, logicDB);
            inputMobilesForm.SetLogger(logger);
            inputMobilesForm.ShowDialog();
        }
        
        public async Task<GetPhoneList> GetInstance(string[] pathNames)
        {
            await ParserFiles(pathNames, true);
            return  actual_base;
        }

        // Очередь Выделенных файлов на Повтор files = список выделенных файлов
        private async Task ParserFiles(string[] files, bool delete_file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(files[0]));

            Dictionary <string, GetPhoneList> DefCode = new Dictionary<string, GetPhoneList>(10);

            foreach (var file in files)
            {
               
                foreach (var line in File.ReadLines(file, Encoding.GetEncoding(1251)).Skip(1))
                {
                    if (SettingFilePath.defkod != defFileCode)
                        GetDefCode(file, line); 

                    if (TypeFile(file, line))
                    {
                        PhoneTypeRepeat(file, TypeFileSave.TypeFiles.Actualization);
                        break;
                    }
                    else
                    {
                        PhoneTypeRepeat(file, TypeFileSave.TypeFiles.Repeater);
                        break;
                    }
                }

                if (await logicDB.GetSearthDefCode(SettingFilePath.defkod) == SearchThis.Yes)
                {
                    actual_base = GetBaseInstance(files,  await Logic.GetOpetatorFromDefAsync(SettingFilePath.defkod), answer, not_answer, skipped);      //TODO Если код найден     
                }

                else
                {
                    if (MessageBox.Show("Don't found. Add this ? ", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CreateFormInputMobile();
                        actual_base =  GetBaseInstance(files, await Logic.GetOpetatorFromDefAsync(SettingFilePath.defkod), answer, not_answer, skipped);
                    }

                    else actual_base = null;
                }
            }
        }

       

        private void GetDefCode(string file, string line)
        {
            //89046669723
            var result = line.Split(new[] { ';' })[0];
            defFileCode = result.Substring(1, 3) + "-" + result.Substring(4, 3);
            SettingFilePath.defkod = defFileCode;
        }

        private bool TypeFile(string file, string line)
        {
            var lines = line.Split(new[] { ';' });
            //Актуализация    89270370703;Занято
            //       if (line.Split(new[] { ';' })[1] != "C") return true;
            if (lines.Count() <= 2) return true;
            //Повтор  89046669723;C;2018-04-14 12:13:53;1;0;13;Кокоянина Анна;99
            return false;
        }        

        public void PhoneTypeRepeat(string file, TypeFileSave.TypeFiles typeFiles)  
        {
            var queryActual = from phone in File.ReadAllLines(file, Encoding.GetEncoding(1251)).Skip(1)
                              let phoneLine = phone.Split(new[] { ';' })
                              where  CutPhoneNumber.FoundDoublePhone(phoneLine[0], open_phone_number) == false
                              select new
                              {
                                  PhoneNumber = phoneLine[0].ToString(),
                                  TypePhone = phoneLine[1].ToString(),
                              };

            var queryRepeat = from phone in File.ReadAllLines(file, Encoding.GetEncoding(1251)).Skip(1)
                              let phoneLine = phone.Split(new[] { ';' })
                              where CutPhoneNumber.FoundDoublePhone(phoneLine[0], open_phone_number) == false && 
                                    (CutNumbersCode(phoneLine[(phoneLine.Count() - 1)]) == false) 
                              select new
                              {
                                  PhoneNumber = phoneLine[0].ToString()
                              };
            
            if (typeFiles == TypeFileSave.TypeFiles.Repeater)
                switch (SwitchTypeNumbers(Path.GetFileName(file)))
                {
                    case FileName.TypeRu.ПАС:
                        foreach (var result in queryRepeat)
                            skipped.phone.Add(result.PhoneNumber);
                            skipped.PathFile = file;
                        break;
                    case FileName.TypeRu.Не_Ответ:
                        foreach (var result in queryRepeat)
                            not_answer.phone.Add(result.PhoneNumber);
                            not_answer.PathFile = file;
                        break;
                    case FileName.TypeRu.Ответ:
                        foreach (var result in queryRepeat)
                            answer.phone.Add(result.PhoneNumber);
                            answer.PathFile = file;
                        break;
                }

            else if (typeFiles == TypeFileSave.TypeFiles.Actualization)
            {
                foreach (var result in queryActual)
                    switch (result.TypePhone)
                    {
                        case "Ответ":
                            answer.phone.Add(result.PhoneNumber);
                            break;
                        case "Не отвечает":
                            not_answer.phone.Add(result.PhoneNumber);
                            break;
                        case "Занято":
                            skipped.phone.Add(result.PhoneNumber);
                            break;
                    }
                answer.PathFile = file;
                not_answer.PathFile = file;
                skipped.PathFile = file;
            }
        }

        //Пас Ответ Не_ответ
        private FileName.TypeRu SwitchTypeNumbers(string name)
        {
            if ((name.IndexOf(FileName.TypeRu.ПАС.ToString(), StringComparison.OrdinalIgnoreCase) != -1) || 
                (name.IndexOf(FileName.TypeEn.Skipped.ToString(), StringComparison.OrdinalIgnoreCase) != -1))
            {
                return FileName.TypeRu.ПАС;
            }
            else if ((name.IndexOf(FileName.TypeRu.Не_Ответ.ToString(), StringComparison.OrdinalIgnoreCase) != -1) ||
                (name.IndexOf(FileName.TypeEn.No_Answer.ToString(), StringComparison.OrdinalIgnoreCase) != -1))
            {
                return FileName.TypeRu.Не_Ответ;
            }
            else
            {
                return FileName.TypeRu.Ответ;
            }
        }

        //77 99
        private bool CutNumbersCode(string line)
        {
            foreach (var cutCode in SettingFilePath.cutCodes)
                {
                    if (cutCode == line)
                    {
                        return true;
                    }
                }
            return false;
        }

        public GetPhoneList GetBaseInstance( string[] files, ResultDefCode resultDefCode, AnswerClass answer, NotAnswerClass no_answer, SkippedClass skipped)
        {
            return new GetPhoneList() {files = files, resultDefCode = resultDefCode, answer = answer, no_answer = no_answer, skipped = skipped };
        }
    }
}

    

