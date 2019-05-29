using CrmManager.CrmDB;

namespace CrmManager.CsvParsing.customList
{
    class SkippedClass:AbstractPhone
    {
        public SkippedClass(Logic logicDB) : base(logicDB)
        {
            TypeFile_EN = FileName.TypeEn.Skipped;
            TypeFile_RU = FileName.SwitchRuLanguage(FileName.TypeEn.Skipped);
        }
    }
}
