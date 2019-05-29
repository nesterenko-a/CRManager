using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using CrmManager.CrmApi.Models;
using Newtonsoft.Json;
using CrmManager.CsvParsing.customList;
using System.Text;
using System.Net.Http.Headers;
using System.Windows.Forms;
using CrmManager.CsvParsing;
using System.Globalization;
using CrmManager.CrmDB.QueryDB;

namespace CrmManager.CrmApi
{
    public class CrmApiManager
    {
        private Logger logger;

        private HttpClientHandler handler;
        private HttpClient client;
        private string csrf_token;

        private string login;
        private string password;
        private string serverName;

        private string call_project_id;
        private string provider_id;
        private AbstractPhone abstractPhone;
        private bool resultUploadFile = false;

        public string Csrf_token
        {
            get
            {
                if (csrf_token == null)
                    SingleForm.LoginFormInstance(this).ShowDialog();
                return csrf_token;
            }

            set
            {
                csrf_token = value;
            }
        }

        public bool ResultUploadFile
        {
            get { return resultUploadFile; }
            set { resultUploadFile = value; }
        }
        public void SetLogger(Logger logger)
        {
            this.logger = logger;
        }

        public void SetCredentials(string login, string password, string serverName)
        {
            if (this.login != login || this.password != password || this.serverName != serverName)
            {
                client = null;
            }
        }

        #region Базы Дозвона https://crmyar.bbclinics.pro/CallBase
        /// <summary>
        /// CallBase Upload File.
        /// </summary>
        /// <param name="call_project_id">ID City</param>
        /// <param name="provider_id">ID mobile provider</param>
        /// <param name="abstractPhone">Body Abstract phone</param>
        /// <returns>async Task</returns>
        public async Task PostCallBaseCreate(string call_project_id, string provider_id, AbstractPhone abstractPhone, string aktualizMark = "")
        {
            this.abstractPhone = abstractPhone;
            this.call_project_id = call_project_id;
            this.provider_id = provider_id;

            var is_active = await CheckSession();
            if (!is_active)
            {
                throw new Exception("Cannot log in");
            }

            ResultUploadFile = await PostCallBaseFileSave(); // Загружаем физически сам файл и если загрузка проперла то продолжаем
            if (!ResultUploadFile)
            {
                throw new Exception("File was not uploaded :'(");
            }
            logger.Log("File is uploaded, continue");

            var values = new Dictionary<string, string>
            {
                {"sort", ""},
                {"group", ""},
                {"filter", ""},
                {"callProject_Id", call_project_id},
                {"numbersFileName", abstractPhone.GetFileNamePostFileSave() },
                {"Id", "0"},
                {"HashCode", "0"},
                {"Name", abstractPhone.DefCod(AbstractPhone.TypeDefCodeFormat.ShortFormat) },
                {"Description", abstractPhone.GetDescriptionRU() + aktualizMark},
                { "CallProject_Id", call_project_id},
                {"Provider_Id", provider_id},
               // {"LoadDate", DateTime.Now.ToString()},
                {"IsActive", "false"},
                {"Capacity", "0"},
                {"Counter", "0"},
                {"CounterPercent", "0"},
                {"NumbersFileName", ""},
                {"NumbersFileContent", ""},
                {"CheckDoubles", "false"},
                {"LastAssignDate", ""},
                {"ShortCallsAutoDeActivationTime", ""},
            };
            var content = new FormUrlEncodedContent(values);
            var response = await GetClient().PostAsync("/CallBase/Create", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("POST /CallBase/Create: remote server returns code: " + response.StatusCode);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            CallBaseCreateModel responseModel = JsonConvert.DeserializeObject<CallBaseCreateModel>(responseString);
            if (responseModel.Total < 1 || responseModel.Data.Length < 1 || responseModel.Data[0].Id == 0)
            {
                throw new Exception("POST /CallBase/Create: remote server returns malformed result: " + responseString);
            }
            logger.Log("POST /CallBase/Create: success");

            var is_allocated = await GetCallBaseAllocate(responseModel.Data[0].Id);
            if (!is_allocated)
            {
                logger.Log("We're gonna die");
            }
            logger.Log("Good shit");
        }

        private async Task<bool> PostCallBaseFileSave()
        {
            if (Csrf_token == null)
            {
                throw new Exception("csrf_token is null");
            }
            var tokenContent = new StringContent(Csrf_token);
            var bodyContent = String.Join("\n", abstractPhone.phone);
            string path = abstractPhone.GetFileNamePostFileSave(); // "1234556_отве_P01.txt"    ??????????

            var fileStreamContent = new StringContent(bodyContent);
            using (var content = new MultipartFormDataContent())
            {
                content.Add(tokenContent, "__RequestVerificationToken");
                content.Add(fileStreamContent, "files", path);
                var response = await GetClient().PostAsync("/CallBase/FileSave", content);
                if (!response.IsSuccessStatusCode)
                {
                    logger.Log("Remote server returns code: " + response.StatusCode);
                    return false;
                }
                logger.Log("PostCallBaseFileSave: success uploading: " + path);
            }
            return true;
        }
        private async Task<bool> GetCallBaseAllocate(int project_id)
        {
            var response = await GetClient().GetAsync("/CallBase/Allocate?id=" + project_id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("GET /CallBase/Allocate?id=" + project_id +
                    ": remote server returns code: " + response.StatusCode);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            return true;
        }
        #endregion

        #region Актуализация https://crmyar.bbclinics.pro/CheckBase
        public async Task PostCheckBaseCreate(ResultDefCode resultDefCode, string description = "")
        {         
                var is_active = await CheckSession();
                if (!is_active)
                {
                    throw new Exception("Cannot log in");
                }

                var values = new Dictionary<string, string>
                {
                    {"sort","" },
                    { "group","" },
                    { "filter","" },
                    { "checkProject_Id", resultDefCode.CityIdName.ToString() },
                    { "Id","0" },
                    { "HashCode","0" },
                    { "Name", resultDefCode.DefCodeName },
                    { "Description", description},
                    { "CheckProject_Id", resultDefCode.CityIdName.ToString() },
                    { "Provider_Id", resultDefCode.OperatorIdName.ToString()},
                    { "LoadDate", DateTime.Now.ToString()},
                    { "Capacity","0"},
                    { "StartNum", $"8{resultDefCode.DefCodeName.Replace("-","")}0000"},
                    { "EndNum", $"8{resultDefCode.DefCodeName.Replace("-","")}9999"},
                    { "NumbersFileName",""},
                    { "NumbersFileContent",""},
                    { "IsActive","false"},
                    { "HasNumbers", "false"},
                    { "IsCallBased","false"},
                    { "IsCallLoadCallBaseAnswer","false"},
                    { "IsCallLoadCallBaseReset","false"},
                    { "IsCallLoadCallBasePAS", "false"},
                    { "CheckDoubles","false"},
                    { "CallProject_Id","0"}
                };

                logger.Log("File is uploaded, continue");
                var content = new FormUrlEncodedContent(values);
                var response = await GetClient().PostAsync("/CheckBase/Create", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("POST /CheckBase/Create: remote server returns code: " + response.StatusCode);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                CheckBaseCreateModel responseModel = JsonConvert.DeserializeObject<CheckBaseCreateModel>(responseString);
                if (responseModel.Total < 1 || responseModel.Data.Length < 1 || responseModel.Data[0].Id == 0)
                {
                    throw new Exception("POST /CheckBase/Create: remote server returns malformed result: " + responseString);
                }
                logger.Log("POST /CheckBase/Create: success");

                var is_allocated = await GetCheckBaseAllocate(responseModel.Data[0].Id);
                if (!is_allocated)
                {
                    logger.Log("We're gonna die");
                }
                logger.Log("Good shit");
        }

        public async Task PostCheckBaseCreate(string checkProject_Id, string provider_id, AbstractPhone abstractPhone, string description = "")
        {
            if (PathSettings.Default.RepeatActualiz <= abstractPhone.CountRepeatPhone)
            {
                this.abstractPhone = abstractPhone;
                this.call_project_id = checkProject_Id;
                this.provider_id = provider_id;

                var is_active = await CheckSession();
                if (!is_active)
                {
                    throw new Exception("Cannot log in");
                }
               
                var values = new Dictionary<string, string>
                {
                    {"sort","" },
                    { "group","" },
                    { "filter","" },
                    { "checkProject_Id",call_project_id },
                    { "Id","0" },
                    { "HashCode","0" },
                    { "Name", abstractPhone.DefCod(AbstractPhone.TypeDefCodeFormat.ShortFormat) },
                    { "Description", description},
                    { "CheckProject_Id", call_project_id},
                    { "Provider_Id", provider_id},
                    { "LoadDate", DateTime.Now.ToString()},
                    { "Capacity","0"},
                    { "StartNum",$"8{abstractPhone.DefCod(AbstractPhone.TypeDefCodeFormat.LongFormat)}0000"},
                    { "EndNum",$"8{abstractPhone.DefCod(AbstractPhone.TypeDefCodeFormat.LongFormat)}9999"},
                    { "NumbersFileName",""},
                    { "NumbersFileContent",""},
                    { "IsActive","false"},
                    { "HasNumbers", "false"},
                    { "IsCallBased","false"},
                    { "IsCallLoadCallBaseAnswer","false"},
                    { "IsCallLoadCallBaseReset","false"},
                    { "IsCallLoadCallBasePAS", "false"},
                    { "CheckDoubles","false"},
                    { "CallProject_Id","0"}
                };
                logger.Log("File is uploaded, continue");
                var content = new FormUrlEncodedContent(values);
                var response = await GetClient().PostAsync("/CheckBase/Create", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("POST /CheckBase/Create: remote server returns code: " + response.StatusCode);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                CheckBaseCreateModel responseModel = JsonConvert.DeserializeObject<CheckBaseCreateModel>(responseString);
                if (responseModel.Total < 1 || responseModel.Data.Length < 1 || responseModel.Data[0].Id == 0)
                {
                    throw new Exception("POST /CheckBase/Create: remote server returns malformed result: " + responseString);
                }
                logger.Log("POST /CheckBase/Create: success");

                var is_allocated = await GetCheckBaseAllocate(responseModel.Data[0].Id);
                if (!is_allocated)
                {
                    logger.Log("We're gonna die");
                }
                logger.Log("Good shit");
            }

        }
        private async Task<bool> PostCheckBaseFileSave()
        {
            if (Csrf_token == null)
            {
                throw new Exception("csrf_token is null");
            }
            var tokenContent = new StringContent(Csrf_token);
            var bodyContent = abstractPhone.phone.ToString();

            string path = abstractPhone.GetFileNamePostFileSave(); // "1234556_отве_P01.txt"    ??????????
            var fileStreamContent = new StringContent(bodyContent);
            using (var content = new MultipartFormDataContent())
            {
                content.Add(tokenContent, "__RequestVerificationToken");
                content.Add(fileStreamContent, "files", path);
                var response = await GetClient().PostAsync("/CheckBase/FileSave", content);
                if (!response.IsSuccessStatusCode)
                {
                    logger.Log("Remote server returns code: " + response.StatusCode);
                    return false;
                }
                logger.Log("PostCallBaseFileSave: success uploading: " + path);
            }
            return true;
        }
        private async Task<bool> GetCheckBaseAllocate(int project_id)
        {
            var response = await GetClient().GetAsync("/CheckBase/Allocate?id=" + project_id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("GET /CheckBase/Allocate?id=" + project_id +
                    ": remote server returns code: " + response.StatusCode);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            return true;
        }
        #endregion

        ///CheckBase/FileSave
        private HttpClient GetClient()
        {
            if (client != null)
            {
                //Properties.Settings.Default.Cookie = Csrf_token;
                //Properties.Settings.Default.Save();
                return client;
            }
            Csrf_token = null;
            var baseAddress = new Uri(serverName);
            var cookieContainer = new CookieContainer();
            handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            client = new HttpClient(handler, false) { BaseAddress = baseAddress };
            return client;
        }
        public async Task<bool> CheckSession()
        {
            // TODO Csrf_token = null;
            if (Csrf_token == null)
            {
                var response = await GetClient().GetAsync("/");
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var responseString = await response.Content.ReadAsStringAsync();
                if (!HasLoginForm(responseString))
                {
                    Csrf_token = ParseCsrfToken(responseString);
                    return true;
                }
                return await LoginAsync(login, password, serverName);
            }
            else
            {
                var response = await GetClient().GetAsync("/");
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> LoginAsync(string login, string password, string serverName)
        {
            SetCredentials(login, password, serverName);

            this.login = login;
            this.password = password;
            this.serverName = serverName;

            var token = await GetLoginFormTokenAsync();
            if (token == "")
            {
                throw new Exception("Login form token is empty");
            }

            var values = new Dictionary<string, string>
            {
                {"__RequestVerificationToken", token},
                {"Email", login},
                {"Password", password},
                {"RememberMe", "false"}
            };

            var content = new FormUrlEncodedContent(values);
            var response = await GetClient().PostAsync("/Account/Login", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Remote server returns code: " + response.StatusCode);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var success = !HasLoginForm(responseString);
            if (success)
            {
                Csrf_token = ParseCsrfToken(responseString);
            }

            logger.Log("Login success: " + success);
            PrintCookies();
            return success;
        }
        private async Task<string> GetLoginFormTokenAsync()
        {
            var form_token = "";
            var response = await GetClient().GetAsync("/");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Remote server returns code: " + response.StatusCode);
            }

            var responseString = await response.Content.ReadAsStringAsync();
            form_token = ParseCsrfToken(responseString);
            logger.Log("Login form token: " + form_token);
            PrintCookies();

            return form_token;
        }
        private bool HasLoginForm(string content)
        {
            return Regex.IsMatch(content, @"form\s+action=\\*""/Account/Login", RegexOptions.Multiline);
        }
        private string ParseCsrfToken(string content)
        {
            foreach (Match match in Regex.Matches(content, "__RequestVerificationToken.+value=\"(.+)\"\\s*\\/\\>"))
            {
                return match.Groups[1].Value;
            }
            return null;
        }
        private void PrintCookies()
        {
            logger.Log("===== cookies start ===== \r\n" +
                handler.CookieContainer.GetCookieHeader(new Uri(serverName)) +
                "\r\n===== cookies end =====");
        }

        private static string UploadFileBasename(string filename)
        {
            var fileInfo = new FileInfo(filename);
            return fileInfo.Name;
        }

        //Нигде не используется
        private async Task GetCallBase()
        {
            var is_active = await CheckSession();
            if (!is_active)
            {
                throw new Exception("Cannot log in");
            }

            var response = await GetClient().GetAsync("/CallBase");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Remote server returns code: " + response.StatusCode);
            }
            var responseString = await response.Content.ReadAsStringAsync();
            logger.Log(responseString);
        }
    }
}
