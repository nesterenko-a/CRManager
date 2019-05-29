using CrmManager.CrmDB;

namespace CrmManager.CsvParsing.customList
{
    public class AnswerClass: AbstractPhone
    {
        public AnswerClass(Logic logicDB) : base(logicDB)
        {
            TypeFile_EN = FileName.TypeEn.Answer;
            TypeFile_RU = FileName.SwitchRuLanguage(FileName.TypeEn.Answer);
        }
        //public override string TypeName()
        //{
        //    TypeFile_EN = FileName.TypeEn.Answer.ToString();
        //    TypeFile_RU = FileName.SwitchRuLanguage(FileName.TypeEn.Answer).ToString();
        //}
    }
}
