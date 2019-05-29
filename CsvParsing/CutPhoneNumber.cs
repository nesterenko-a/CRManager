using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace CrmManager.CsvParsing
{
    static class CutPhoneNumber
    {
       
        /// <summary>
        /// Не записываем если найден повтор из Продажа & Завершено
        /// </summary>
        /// <param name="line">Строка которую сравниваем на добавление</param>
        /// <param name="open_phone_number">Из чего сравниваем OpenFileNumber</param>
        /// <returns>false = not found ; true = found </returns>
        public static bool FoundDoublePhone(string line, List<string> open_phone_number)
        {
            //TODO: Сделать LINQ Except
            try
            {
                foreach (var result in open_phone_number)
                {
                    if (result == line) return true;                
                }               
            }
            catch (Exception e)
            {
                MessageBox.Show("Файл повторов так и не был передан \n" + e.ToString());
                throw new Exception("Файл повторов так и не был передан \n" + e.ToString());            
            }

            return false;
        }

        public static IEnumerable<string> ExceptStopList(this IEnumerable<string> inList, List<string> open_phone_number)
        {
            return inList.Except(open_phone_number);
        }
    }
}
