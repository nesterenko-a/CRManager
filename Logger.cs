using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using
namespace CrmManager
{
    public class Logger
    {
        private TextBox text_box;

        public Logger(TextBox text_box)
        {
            this.text_box = text_box;
        }

        public void Log(string text)
        {
            //try
            //{
            //    if (text_box.InvokeRequired)
            //    {
                    text_box.Invoke(new Action(() => { text_box.Text += DateTime.Now.ToString() + ": " + text + "\r\n"; }));
            //    }
            //}
            //catch
            //{
            //    throw new Exception();
            //}
        }
    }

    public static class StaticLogger
    {
        private static StringBuilder StringLog = new StringBuilder();
        private static string tempString = default;


        public static string Write(string logs)
        {
            tempString = $"{DateTime.Now.ToString()}: {logs}";
            StringLog.AppendLine(tempString);
            return tempString;
        }

        public static string Read()
        {
            return StringLog.ToString();
        }

        public static void Clear()
        {
            StringLog.Clear();
        }
    }
}
