using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmManager
{
    public static class TrialManager
    {
        public static int DaysLeft { get; private set; }
        public static string pathRegKey;
        private static string temp = "";
        public static Logger logger;
        public static Microsoft.Win32.RegistryKey EncryptedKey;
        private static bool microsoftDate = false;

        private static DateTime dateNow;
        public static async Task<DateTime> GetNowDateTimeAsync()
        {
            if (!microsoftDate)
            {
                microsoftDate = true;
                dateNow = await GetNistTime();
                return dateNow;
            }
            logger.Log(dateNow.ToString());
            return dateNow;
        }

        public static async Task TrialDemoManagerAsync(string pathRegKey)
        {
            TrialManager.pathRegKey = pathRegKey;
            try
            {
                RSACryptoServiceProvider crypto = new RSACryptoServiceProvider(); // почитать про это
                EncryptedKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\" + pathRegKey);
                object value = EncryptedKey.GetValue(pathRegKey);

                if (value == null)
                {
                    await SetNewPromoAsync(pathRegKey, 31);
                }
                else
                {
                    string key = DecryptPassword(value.ToString());
                    DateTime dateTime = Convert.ToDateTime(key);
                    await ExpiredAsync(dateTime);
                }
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
        }

        public static void SetLogger(Logger logger)
        {
            TrialManager.logger = logger;
        }

        #region KidsCryptDecript
        private static string EncryptPassword(string textPassword)
        {
            //Input   
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(textPassword);
            string encryptPass = Convert.ToBase64String(passBytes);
            return encryptPass;
        }

        private static string DecryptPassword(string encryptedPassword)
        {
            //output
            //TODO: Энкрипт ключа триала. Посмотреть вставить.
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }
        #endregion

        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                logger.Log(hashedInputStringBuilder.ToString());
                return hashedInputStringBuilder.ToString();
            }
        }

        public static async Task SetNewPromoAsync(string pathRegKey, int days)
        {
            EncryptedKey.SetValue(pathRegKey, EncryptPassword(await SetNewDateAsync(days)));
        }

        private static async Task<string> SetNewDateAsync(int days)
        {
            DateTime newDate = (await Task.Run(async () => await GetNowDateTimeAsync())).AddDays(days); //await GetNowDateTime().Result .AddDays(days);
           // newDate.AddDays(day);
            temp = newDate.ToLongDateString();
            return temp;
        }

        public static async Task<string> DateTimeToStringAsync()
        {
            DateTime newDate = await  GetNowDateTimeAsync();
            temp = newDate.ToShortDateString();
            logger.Log(temp);
            return temp;
        }

        private static async Task ExpiredAsync(DateTime dateTime)
        {
            DaysLeft = (dateTime.Subtract(await GetNowDateTimeAsync())).Days;
            if (DaysLeft > 30) { }
            else if (0 < DaysLeft && DaysLeft <= 30)
            {
                logger.Log(string.Format("{0} days more to expire", DaysLeft));
            }
            else if (DaysLeft <= 0)
            {
                var result = new TrialForm();
                result.ShowDialog();
            }
        }

        public static async Task<DateTime> GetNistTime()
        {
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                var response = await myHttpWebRequest.GetResponseAsync();
                string todaysDates = response.Headers["date"];
                DateTime dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
                return dateTime;
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                MessageBox.Show(ex.Message + "\n or нет соединения с Интернетом", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
                return dateNow;
            }

        }
    }
    
}
