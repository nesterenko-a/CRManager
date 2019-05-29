using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmManager.CrmApi;
using CsvParsingManager.CsvParsing;
using CrmManager.CsvParsing;
using CrmManager.CrmDB;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using CrmManager.Forms;
using System.Threading;
using System.Drawing;
using CrmManager.CrmDB.QueryDB;
using CrmManager.CsvParsing.WaitActualization;
using CrmManager.Helpers;

namespace CrmManager
{
    public partial class CrmForm : Form
    {
        private InputMobilesForm inputMobilesForm;

        private CrmApiManager crm_api;
        private Logic logicDB;
        private Logger logger;
        private int instancePhoneCount = 0;

        private Dictionary<string, GetPhoneList> instanceDictionaryPhone;
        private Dictionary<string, GetPhoneList> instanceBasePhone;
        private Dictionary<string, List<string>> listDef; // key = 974-544, value = C:\\974-544_no_answer.csv 

        private WriteFilePhoneAllType writeFilePhoneAllType;


        private WaitActManager waitAct;
        private int InstancePhoneCount
        {
            get
            {
                return instancePhoneCount;
            }
            set
            {
                instancePhoneCount = value;
                lblCountPhone.Text = instancePhoneCount.ToString();
            }
        }

        private void Reset()
        {
            instancePhoneCount = 0;
            pgbInstanceCount.Maximum = listDef.Keys.Count;
            pgbInstanceCount.Value = 0;
            lsUploadInstance.Items.Clear();
            timerFileCount.Enabled = true;
        }

        public CrmForm()
        {
            InitializeComponent();
            
            //Если файл с настройками не найден то мы открываем файл и создаем их (если их нет) записывая настройки поумолчанию
            SettingFilePath.FileExistMethod();

            logger = new Logger(txtLog);  //Подключаем ведение Loga s DataBase

            crm_api = new CrmApiManager();
            crm_api.SetLogger(new Logger(txtLog));  //Подключаем ведение Loga s DataBase

            logicDB = new Logic();
            logicDB.SetLogger(new Logger(txtLog)); //Подключаем ведение Loga s DataBase

            #region FilterActual
            operatorNameCBox.DataSource = Logic.GetOperatorList();
            operatorNameCBox.DisplayMember = "Name";
            operatorNameCBox.ValueMember = "id_operator";
            operatorNameCBox.SelectedIndexChanged += OperatorNameCBox_SelectedIndexChanged;
            #endregion

            #region Add listbox deserialize actual field ..Config//actualization.json
            waitAct = new WaitActManager();
            waitAct.GetDeserializeFromJson();
            #endregion

           

            ShowListAct();

        }

        private void OperatorNameCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operator operatorResult = (Operator)operatorNameCBox.SelectedItem;
            ShowListAct(operatorResult.Name);
        }

        #region Событие закрытия главной формы
        private void EventCloseForm(object sender, FormClosingEventArgs a)
        {
            if (a.CloseReason != CloseReason.UserClosing) return;

            var resultDialog = MessageBox.Show("Выйти из программы?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDialog != DialogResult.Yes) a.Cancel = resultDialog == DialogResult.No;
            else Application.Exit();
        }
        #endregion

        private string MarkActualiz(int Count)
        {
            if (PathSettings.Default.RepeatActualiz <= Count)
            {
                return " АКТ";
            }
            return "";
        }

        private async void SetFilesToCRM(object sender, MouseEventArgs e)
        {
            int index = this.lsUploadInstance.IndexFromPoint(e.Location);
            string namefile = this.lsUploadInstance.Items[index].ToString();
            try
            {
                if (index != ListBox.NoMatches)
                {
                    foreach (KeyValuePair<string, GetPhoneList> keyValue in instanceDictionaryPhone)
                    {
                        if (keyValue.Key == namefile)
                        {
                            // из-за раздвоения Петербургского проекта на КЦ Петербург и КЦ Робот
                            string idCity = keyValue.Value.resultDefCode.CityIdName.ToString();
                            if (idCity == "56")
                            {
                                if (rbPeter.Checked) idCity = "56";
                                if (rbRobot.Checked) idCity = "59";
                                if (rbSanktYar.Checked) idCity = "83";

                            }
                            ///////////////

                            string idProvider = keyValue.Value.resultDefCode.OperatorIdName.ToString();

                            #region FindTypeFiles

                            #region ПАС
                            if (Regex.IsMatch(namefile, FileName.TypeRu.ПАС.ToString(), RegexOptions.IgnoreCase))
                            {
                                try
                                {
                                    if (await Waiter(lsUploadInstance, () => crm_api.PostCallBaseCreate(idCity, idProvider, keyValue.Value.skipped, MarkActualiz(keyValue.Value.skipped.CountRepeatPhone))) == true)
                                    {
                                        writeFilePhoneAllType = new WriteFilePhoneAllType(keyValue.Value, keyValue.Value.skipped);
                                        lsUploadInstance.Items.RemoveAt(index);
                                        InstancePhoneCount -= keyValue.Value.GetCountPhoneInstance(FileName.TypeRu.ПАС);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Загрузка не удалась");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    logger.Log(ex.ToString());
                                }

                            }
                            #endregion

                            #region Не_Ответ
                            else if (Regex.IsMatch(namefile, FileName.TypeRu.Не_Ответ.ToString(), RegexOptions.IgnoreCase))
                            {
                                try
                                {
                                    if (await Waiter(lsUploadInstance, () => crm_api.PostCallBaseCreate(idCity, idProvider, keyValue.Value.no_answer, MarkActualiz(keyValue.Value.no_answer.CountRepeatPhone))) == true)
                                    {
                                        writeFilePhoneAllType = new WriteFilePhoneAllType(keyValue.Value, keyValue.Value.no_answer);
                                        lsUploadInstance.Items.RemoveAt(index);
                                        InstancePhoneCount -= keyValue.Value.GetCountPhoneInstance(FileName.TypeRu.Не_Ответ);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error upload file in CRM");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    logger.Log(ex.ToString());
                                }
                            }
                            #endregion

                            #region Ответ
                            else if (Regex.IsMatch(namefile, FileName.TypeRu.Ответ.ToString(), RegexOptions.IgnoreCase))
                            {
                                try
                                {

                                    if (await Waiter(lsUploadInstance, () => crm_api.PostCallBaseCreate(idCity, idProvider, keyValue.Value.answer, MarkActualiz(keyValue.Value.answer.CountRepeatPhone))) == true)
                                    {
                                        writeFilePhoneAllType = new WriteFilePhoneAllType(keyValue.Value, keyValue.Value.answer);
                                        lsUploadInstance.Items.RemoveAt(index);
                                        instancePhoneCount -= keyValue.Value.GetCountPhoneInstance(FileName.TypeRu.Ответ);

                                        if (PathSettings.Default.RepeatActualiz <= keyValue.Value.answer.CountRepeatPhone)
                                        {
                                            if (await Waiter(lsUploadInstance, () => crm_api.PostCheckBaseCreate(ActualizIdCity(idCity), idProvider, keyValue.Value.answer, descriptiontxtbox.Text)) == true) { }
                                            else
                                            {
                                                ResultDefCode resultDefCode = new ResultDefCode()
                                                {
                                                    CityIdName = Convert.ToInt64(ActualizIdCity(idCity)),
                                                    CityName = keyValue.Value.resultDefCode.CityName,
                                                    DefCodeName = keyValue.Value.resultDefCode.DefCodeName,
                                                    OperatorIdName = keyValue.Value.resultDefCode.OperatorIdName,
                                                    OperatorName = keyValue.Value.resultDefCode.OperatorName
                                                };
                                                waitAct.RemodeAndRefreshListAct(listActualbox, resultDefCode);

                                                MessageBox.Show("Загрузка актуализации не удалась.\r\n Добавлена в очередь.");


                                                //TODO Добавить добавление файла в список очереди на акт. 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Загрузка не удалась");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                    logger.Log(ex.ToString());
                                }
                            }
                            #endregion

                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Log(ex.Message);
            }
        }

        //Костыль из-за несовпадение Актуализации и Базы Повторов
        private string ActualizIdCity(string idCity)
        {
            switch (idCity)
            {
                case "48": idCity = "49"; break; //Ярославль
                case "56" when (rbPeter.Checked == true): idCity = "57"; break; //Петербург
                case "56" when (rbSanktYar.Checked == true): idCity = "65"; break; //Санк-Ярославль https://yar.mdcnt.ru/
                case "56" when (rbRobot.Checked == true): idCity = "60"; break; //СПБ
                case "55": idCity = "55"; break; //Казань
                default: throw new Exception("Not find Project id");
            }

            return idCity;
        }

        //Upload actualization data 
        private async void SetActToCRM(object sender, MouseEventArgs e)
        {
            int index = listActualbox.IndexFromPoint(e.Location);
            string namefile = listActualbox.Items[index].ToString();
            try
            {
                if (index != ListBox.NoMatches)
                {
                    var result = waitAct.DataActualization.ResultDefCodes.FirstOrDefault((t) => namefile.Contains(t.DefCodeName));

                    if (result != null)
                    {
                        try
                        {
                            await Waiter(listActualbox, () => crm_api.PostCheckBaseCreate(result, descriptionManualtxtbox.Text));
                            waitAct.Remove(result);
                            waitAct.SetSerializeFronJson();
                            ShowListAct();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            logger.Log(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Log(ex.Message);
            }
        }

        private async void CrmForm_Load(object sender, EventArgs e)
        {
            try
            {
                lsUploadInstance.MouseDoubleClick += new MouseEventHandler(SetFilesToCRM); //CallBase event
                listActualbox.MouseDoubleClick += new MouseEventHandler(SetActToCRM); //ActualBase event
                                                                                      //Если файл с настройками не найден то мы открываем файл и создаем их (если их нет) записывая настройки поумолчанию
                                                                                      //SettingFilePath.FileExistMethod();
                #region TrialForm
                TrialManager.SetLogger(new Logger(txtLog));
                await TrialManager.TrialDemoManagerAsync("CrmPrograms");

                this.Text += "- days left: " + TrialManager.DaysLeft.ToString();
                FormClosing += new FormClosingEventHandler(EventCloseForm);
                #endregion
                RepeatActBox.Text = PathSettings.Default.RepeatActualiz.ToString();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
        }

        //ListBox Waiter
        private async Task<bool> Waiter(ListBox listBox, Func<Task> task)
        {
            listBox.Enabled = false;
            try
            {
                await task();
                listBox.Enabled = true;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                logger.Log(e.Message);
            }
            listBox.Enabled = true;
            return false;
        }

        private async void btnParsingFile_Click(object sender, EventArgs e)
        {
            OpenFile open = new OpenFile(true, null, TypeFileSave.TypeFiles.CsvFile);
            btnParsingFile.Enabled = false;
            try
            {
                if (open.dialogResult == DialogResult.OK)
                {
                    List<string> defcodeList = new List<string>();
                    SortingFileDefCodesPaths(open.PathNames);
                    Reset();

                    instanceBasePhone = new Dictionary<string, GetPhoneList>();
                    await GetPhoneList(open);

                    PhoneShowDictionary(instanceBasePhone);
                }
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
            finally
            {
                btnParsingFile.Enabled = true;
            }
        }

        #region SortingFileDefCodesPaths => listDef
        // 960-534, C:\960-532_Ответ.txt
        //          C:\960-532_Не_Ответ.txt
        private void SortingFileDefCodesPaths(string[] files)
        {
            listDef = new Dictionary<string, List<string>>();
            foreach (var file in files)
            {
                foreach (var line in File.ReadLines(file, Encoding.GetEncoding(1251)).Skip(1))
                {
                    Add(GetDef(line), file);
                }
            }
        }
        private static string GetDef(string line)
        {
            var result = line.Split(new[] { ';' })[0];
            return result.Substring(1, 3) + "-" + result.Substring(4, 3);
        }
        public void Add(string key, string value)
        {
            if (listDef.ContainsKey(key))
            {
                List<string> list = listDef[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                listDef.Add(key, list);
            }
        }

        #endregion


        private Task GetPhoneList(OpenFile open)
        {
            logger.Log("Start GetPhones ID - " + Thread.CurrentThread.ManagedThreadId.ToString());
            return Task.Run(async () =>
            {
                logger.Log("In GetPhones ID - " + Thread.CurrentThread.ManagedThreadId.ToString());
                foreach (var resule in listDef)
                {
                    string[] sortedDefCode = new string[open.PathNames.Length];
                    sortedDefCode = resule.Value.Select(n => n.ToString()).ToArray();
                    var asd1 = new CsvApiManager(new Logger(txtLog), logicDB);
                    GetPhoneList phoneInctance = await asd1.GetInstance(sortedDefCode);
                    if (phoneInctance != null)
                    {
                        instanceBasePhone.Add(phoneInctance.resultDefCode.DefCodeName, phoneInctance);
                        this.Invoke(new ThreadStart(delegate
                        {
                            logger.Log(phoneInctance.resultDefCode.OperatorName);
                            InstancePhoneCount += phoneInctance.GetCountPhoneInstance(FileName.TypeRu.none);
                            pgbInstanceCount.Value++;
                        }));
                    }
                }
                logger.Log("Out GetPhones ID - " + Thread.CurrentThread.ManagedThreadId.ToString());
            });
        }


        private void PhoneShowDictionary(Dictionary<string, GetPhoneList> instanceBasePhone)
        {
            instanceDictionaryPhone = new Dictionary<string, GetPhoneList>(instanceBasePhone.Keys.Count);
            foreach (var result in instanceBasePhone)
            {
                if (result.Value.answer.phone.Count != 0)
                {
                    lsUploadInstance.Items.Add(result.Value.Show(FileName.TypeRu.Ответ));
                    instanceDictionaryPhone.Add(result.Value.Show(FileName.TypeRu.Ответ), result.Value);
                }

                if (result.Value.no_answer.phone.Count != 0)
                {
                    lsUploadInstance.Items.Add(result.Value.Show(FileName.TypeRu.Не_Ответ));
                    instanceDictionaryPhone.Add(result.Value.Show(FileName.TypeRu.Не_Ответ), result.Value);
                }

                if (result.Value.skipped.phone.Count != 0)
                {
                    lsUploadInstance.Items.Add(result.Value.Show(FileName.TypeRu.ПАС));
                    instanceDictionaryPhone.Add(result.Value.Show(FileName.TypeRu.ПАС), result.Value);
                }
            }
        }

        #region Menu
        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnSignChange_Click(object sender, EventArgs e)
        {
            SingleForm.LoginFormInstance(crm_api).ShowDialog();
        }

        private void mnConfig_Click(object sender, EventArgs e)
        {
            SingleForm.ConfigFormInstance().ShowDialog();
        }

        #region InputMobilesForm
        private void mnAddNewDefCode_Click(object sender, EventArgs e)
        {
            inputMobilesForm = new InputMobilesForm(Logic.GetCityList(), Logic.GetOperatorList(), "", logicDB);
            inputMobilesForm.SetLogger(new Logger(txtLog));
            inputMobilesForm.FormClosing += InputMobilesFormClosing;
            inputMobilesForm.ShowDialog();
        }

        private void InputMobilesFormClosing(object sender, EventArgs e)
        {
            //var city = (sender as InputMobilesForm).SelectedCityes;
            //var mobile = (sender as InputMobilesForm).SelectedOperators;
            //var defcode = (sender as InputMobilesForm).SelectedDefCode;

            //if (city != null & mobile != null & defcode != "   -")
            //    logicDB.AddDefCode(city, mobile, defcode);
            
            //else
            //{
            //    logger.Log("Not add DefCode");
            //}
        }
        #endregion

        #endregion

        private void timerFileCount_Tick(object sender, EventArgs e)
        {
            if (pgbInstanceCount.Value == pgbInstanceCount.Maximum)
            {
                timerFileCount.Enabled = false;
                btnParsingFile.Enabled = true;
            }
        }

        private void RepeatActBox_SelectedValueChanged(object sender, EventArgs e)
        {
            PathSettings.Default.RepeatActualiz = Convert.ToInt32(RepeatActBox.SelectedItem);
            PathSettings.Default.Save();
        }

        private async void addWaitActbtn_Click(object sender, EventArgs e)
        {
            string endDefCode = textDefcodeEnd.Text;
            string stratDefCode = textDefcodeStart.Text;

            try
            {
                if (stratDefCode.CheckMaskedText() == Check.Good)
                {
                    if (endDefCode.CheckMaskedText() == Check.Bad)
                    {
                        endDefCode = stratDefCode;
                    }

                    var defcodeArray = stratDefCode.GetIntArrayDefCode(endDefCode).GetStringArrayDefCode();

                    foreach (var itemDefCode in defcodeArray)
                    {
                        if (await logicDB.GetSearthDefCode(itemDefCode) == SearchThis.Yes)
                        {
                            var defcode = new ResultDefCode();
                            await Task.Run(async () =>
                            {
                                defcode = await Logic.GetOpetatorFromDefAsync(itemDefCode);
                                defcode.CityIdName = Convert.ToInt64(ActualizIdCity(defcode.CityIdName.ToString()));

                            });
                            waitAct.Add(defcode);
                            //TODO Изменить метод Run на Refresh (SetSerializeFronJson + ShowListAct)
                        }
                        else
                        {
                            MessageBox.Show("Нет такого дефкода в БД");
                        }
                    }

                    waitAct.SetSerializeFronJson();
                    ShowListAct();
                    textDefcodeStart.Clear();
                    textDefcodeEnd.Clear();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }



        private void ShowListAct(string contains = " ")
        {
            Operator operatorName = (Operator)operatorNameCBox.SelectedItem;
            contains = operatorName.Name;

            if (contains == "Не определено")
            {
                contains = " ";
            }

            listActualbox.Items.Clear();
            foreach (var t in waitAct.ShowDefCode().Where((t) => t.Contains(contains)))
            {
                listActualbox.Items.Add(t);
            }
        }

        private void listActualbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                waitAct.RemodeAndRefreshListAct((ListBox)sender);
                ShowListAct();
            }
        }

        private async void textDefcodeStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    textDefcodeStart.Enabled = false;
                    textDefcodeStart.Text = textDefcodeStart.Text.Trim();

                    if (textDefcodeStart.Text.CheckMaskedText() == Check.Good)
                    {
                        if (await logicDB.GetSearthDefCode(textDefcodeStart.Text) == SearchThis.Yes)
                        {
                            var code = await Logic.GetOpetatorFromDefAsync(textDefcodeStart.Text);
                            code.CityIdName = Convert.ToInt64(ActualizIdCity(code.CityIdName.ToString()));
                            await crm_api.PostCheckBaseCreate(code, descriptionManualtxtbox.Text);
                            textDefcodeStart.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Нет такого дефкода в БД");
                        }
                    }
                    textDefcodeStart.Enabled = true;
                }
                catch
                {
                    addWaitActbtn_Click(this, new EventArgs());
                }

            }
        }
    }
}


