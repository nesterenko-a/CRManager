using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CrmManager.CsvParsing
{
    public class FileName
    {
        #region CrmIdOperator
        //    //<input type = "checkbox" class="" value="0">[Пусто]
        //    //<input type = "checkbox" class="" value="10">Tele2
        //    //<input type="checkbox" class="" value="13">Билайн
        //    //<input type="checkbox" class="" value="117">Етайп(фикс)
        //    //<input type = "checkbox" class="" value="118">Квант-телеком(фикс)
        //    //<input type = "checkbox" class="" value="8">МегаФон
        //    //<input type="checkbox" class="" value="7">МТС
        //    //<input type="checkbox" class="" value="116">МТТ(фикс)
        //    //<input type = "checkbox" class="" value="57">ОАО "Московская городская телефонная сеть"
        //    //<input type = "checkbox" class="" value="115">ООО "Инвест Мобайл"
        //    //<input type = "checkbox" class="" value="94">ООО "Скартел"
        //    //<input type = "checkbox" class="" value="14">Прочее(фикс)
        //    //<input type = "checkbox" class="" value="114">Ростелеком(фикс)
        //    //<input type = "checkbox" class="" value="9">Смартс
        //    //<input type="checkbox" class="" value="113">Энфорта(фикс)
        #endregion

        public enum TypeRu
        {
            none,
            Ответ,
            Не_Ответ,
            ПАС
        }

        public enum TypeEn
        {
            none,
            Answer,
            No_Answer,
            Skipped
        }

        public static TypeRu SwitchRuLanguage(TypeEn typeEn)
        {
            switch (typeEn)
            {
                case TypeEn.Answer: return TypeRu.Ответ;
                case TypeEn.No_Answer: return TypeRu.Не_Ответ;
                case TypeEn.Skipped: return TypeRu.ПАС;
                default: return TypeRu.none;
            }
        }
    }

    public class FileInfoMethod
    {
        public static string FileBasename(string filename)
        {
            var fileInfo = new FileInfo(filename);
            return fileInfo.Name;
        }
    }

    public class EnumYesNo
    {
        public enum YesNo
        {
            No,
            Yes
        }
    }

    public class TypeFileSave
    {
        public enum TypeFiles : int
        {
            none,
            PhoneNumber,
            CsvFile,
            Actualization,
            Repeater,
            ErrorPathName,
            dbConnectionPath
        }
    }

    public static class LanguageClass
    {
        public enum Language
        {
            RU,
            EN
        }
    }

    public static class RepeaterClass
    {
        public static LanguageClass.Language GetFindLanguage(string input)
        {
            return Regex.IsMatch(input, "[A-Za-z]") ? LanguageClass.Language.EN : LanguageClass.Language.RU;
        }

        public static string GetRedexPatternLanguage(string input)
        {
            return Regex.IsMatch(Path.GetFileNameWithoutExtension(input), "[A-Za-z]") ? @"[P]([0-9]*)" : @"[П]([0-9]*)";
        }

        //public static string IteracionFile(string pathFile, LanguageClass.Language language)
        //{
        //    return language == LanguageClass.Language.RU ? RepeatCount(pathFile, LanguageClass.Language.RU)
        //                                                    : RepeatCount(pathFile, LanguageClass.Language.EN);
        //}

        public static string RepeatCount(string name, LanguageClass.Language language, out int number)
            {
                string pattern = GetRedexPatternLanguage(name);

                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                number = 0;

            if (regex.IsMatch(name))
                {
                    string resultRepeater = regex.Match(name).Value;
                    
                    resultRepeater = resultRepeater.Substring(1, resultRepeater.Length - 1);

                    if (Int32.TryParse(resultRepeater, out number))
                        return language == LanguageClass.Language.RU ? "п" + (number + 1).ToString() : "p" + (number + 1).ToString();
                }
                return language == LanguageClass.Language.RU ? "п0" : "p0";
            }
    }
}


