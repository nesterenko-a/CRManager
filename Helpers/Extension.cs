using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmManager.Helpers
{
    public enum Check
    {
        Bad,
        Good,
    }

    enum Diapozone
    {
        Yes,
        No
    }

    public static class Extension
    {
        private static string ConvertStringDefCode(this int valueDefCode)
        {
            string value = valueDefCode.ToString();
            if (value.Length == 6)
            {
                return value.Insert(3, "-");
            }
            else throw new ArgumentException("Неправильно задан диапазон", nameof(valueDefCode));
        }

        private static int ConvertIntDefCode (this string valueDefCode) //980-765
        {
            if (int.TryParse(valueDefCode.Replace("-", ""),out int result))
            {
                return result;
            }
            else throw new ArgumentException("Неправильно задан диапазон", nameof(valueDefCode));
        }

        public static IEnumerable<string> GetStringArrayDefCode(this int[] array)
        {
            if (array != null)
                foreach (var item in array)
                {
                    yield return item.ConvertStringDefCode();
                }
            else
            {
                new ArgumentNullException($"Массив пуст {nameof(array)}");
            }

        }
            
        public static int[] GetIntArrayDefCode(this string first, string end)
        {
            try
            {
                int[] array = Enumerable.Range(first.ConvertIntDefCode(), end.ConvertIntDefCode() - first.ConvertIntDefCode() + 1).ToArray();
                return array;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            return null;
        }

        public static Check CheckMaskedText(this string defcode)
        {
            if (!string.IsNullOrWhiteSpace(defcode.Replace("-", "")))
            {
                return Check.Good;
            }
            else
            {
                return Check.Bad;
            }
        }
        
    }
}
