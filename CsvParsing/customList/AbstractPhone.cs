using CrmManager.CrmDB;
using CrmManager.CrmDB.QueryDB;
using System.Collections.Generic;

namespace CrmManager.CsvParsing.customList
{
    public abstract class AbstractPhone
    {
        protected Logic logicDB;
      //  protected ResultDefCode resultDefCode;
        public List<string> phone { get; set; }
        private string pathFile = null;
        private string def_cod { get; set; }

        public string GetDefCode
        {
            get { return def_cod; }
        }

        private int countrepeatphone = default;

        public int CountRepeatPhone
        {
            get
            {
                if (countrepeatphone == default)
                {
                    RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.RU, out countrepeatphone);
                }
                return countrepeatphone;
            }
        }

        public virtual string PathFile
        {
            get
            {
                return pathFile;
            }

            set
            {
                if (pathFile == null)
                    pathFile = value;
                   // pathFile = FileInfoMethod.FileBasename(value);
            }
        }
        public FileName.TypeEn TypeFile_EN { get; set; }
        public FileName.TypeRu TypeFile_RU { get; set; }
       
        public virtual int CountPhone()
        {
            return phone.Count;
        }

        public  AbstractPhone(Logic logicDB)
        {
            phone = new List<string>();
            this.logicDB = logicDB;
        }
       // public abstract void TypeName();
        

        //public ResultDefCode ResultDefCode
        //{
        //    get { if (resultDefCode == null) return SotOperator();
        //                                     return resultDefCode;
        //    }
        //}

        //public  virtual ResultDefCode SotOperator()
        //{
        //    if (logicDB.GetSearthDefCode(DefCod()))
        //        {
        //            resultDefCode = logicDB.GetOpetatorFromDef(DefCod());
        //            return resultDefCode;
        //        }
        //    return null;
        //}
       
        /// <summary>
        /// Iteraction file load
        /// </summary>
        /// <param name="pathFile">Name file.txt</param>
        /// <param name="language">RU or EN</param>
        /// <returns>P(Iteraction) or П(Iteraction)</returns>
        //public virtual string IteracionFile(string pathFile, LanguageClass.Language language)
        //{
        //    this.PathFile = pathFile;
        //    return language == LanguageClass.Language.RU ? RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.RU)
        //                                                 : RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.EN);                                                                                                                   
        //}
        public enum TypeDefCodeFormat
        {
            LongFormat,
            ShortFormat
        }

        public virtual string DefCod(TypeDefCodeFormat codeFormat)
        {
            if (def_cod == null)
            {
                this.def_cod = phone[0].Substring(1, 3) + "-" + phone[0].Substring(4, 3);
            }

            return codeFormat == TypeDefCodeFormat.LongFormat ? phone[0].Substring(1, 6) : this.def_cod;
        }

        //public virtual string PathNameShow(LanguageClass.Language language)
        //{
        //    if (language == LanguageClass.Language.EN)
        //        return resultDefCode.OperatorName + "_" + resultDefCode.DefCodeName + "_" + TypeFile_EN + ".txt"; //Билайн_960-555_Answer.txt
        //        return resultDefCode.OperatorName + "_" + resultDefCode.DefCodeName + "_" + TypeFile_RU + ".txt"; //Билайн_960-555_Ответ.txt
        //}

        #region GetFormCRMUpload
        //Ответ П1
        public virtual string GetDescriptionRU() 
        {
            return TypeFile_RU + " " + RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.RU, out countrepeatphone); //Ответ П1
        }

        // 960-555_Answer_P1.txt
        public virtual string GetFileNamePostFileSave()
        {
            return DefCod(TypeDefCodeFormat.ShortFormat) + "_" + TypeFile_EN + "_" + RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.EN, out countrepeatphone) + ".txt";  // 960-555_Answer_P1.txt

        }

        public virtual int GetIntDefCode()
        {
            int def = 0;
            RepeaterClass.RepeatCount(FileInfoMethod.FileBasename(pathFile), LanguageClass.Language.RU, out def);
            return def;
        }
        #endregion
    }
}
