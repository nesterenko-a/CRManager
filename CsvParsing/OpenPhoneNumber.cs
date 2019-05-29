using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CrmManager.CsvParsing
{
    public static class OpenPhoneNumber
    {
        public static List<string> ListPhone(string path)
        {
            if (File.Exists(path) == true)
            {
                using (var reader = new StreamReader(path))
                {
                    List<string> phone = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split('\n');
                        string result = RedexNormalNumber(values[0]); //Подумать о проверке во время заполнения массива ИНДЕКСАТОРОМ (не знаю как работает индексатор в List<string>)

                        if (result != null)
                        {
                            phone.Add(result);
                        }
                    }
                    reader.Close();
                    return phone;
                }
            }
            else
            {
                return null;
            }
        }

        private static string RedexNormalNumber (string redex_phone)
        {
            string pattern = @"([^0-9\n]+)";
            string target = "";
            string result = "";

            Regex regex = new Regex(pattern);

            result = regex.Replace(redex_phone, target);

            if (result.Length == 11) //Если конкретная строка больше ==11 символам то нам подходит 89605554321
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

