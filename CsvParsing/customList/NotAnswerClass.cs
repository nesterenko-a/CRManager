using CrmManager.CrmDB;

namespace CrmManager.CsvParsing.customList
{
    class NotAnswerClass: AbstractPhone
    {
        public NotAnswerClass(Logic logicDB) : base(logicDB)
        {
            TypeFile_EN = FileName.TypeEn.No_Answer;
            TypeFile_RU = FileName.SwitchRuLanguage(FileName.TypeEn.No_Answer);
        }
    }
}
