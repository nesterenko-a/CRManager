using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmManager.CrmDB.QueryDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;
using CrmManager.CrmDB;

namespace CrmManager.CsvParsing.WaitActualization
{

    public class WaitActManager
    {

        private DataActualization dataActualization;
        private string jsonPath;
        private string result = default;

        public DataActualization DataActualization
        {
            get
            {
                if (dataActualization == null)
                {
                    using (StreamReader reader = new StreamReader(jsonPath))
                    {
                        result = reader.ReadToEnd();
                    }
                    dataActualization = JsonConvert.DeserializeObject<DataActualization>(result);
                }
                return dataActualization;
            }
        }
        public WaitActManager(string jsonPath = "Config//actualization.json")
        {
            this.jsonPath = jsonPath;
            dataActualization = new DataActualization();
        }

        public DataActualization GetDeserializeFromJson()
        {
            using (StreamReader reader = new StreamReader(jsonPath))
            {
                result = reader.ReadToEnd();
            }
            dataActualization = JsonConvert.DeserializeObject<DataActualization>(result);

            return dataActualization;
        }

        public List<ResultDefCode> GetResultAct()
        {
            return dataActualization.ResultDefCodes.ToList();
        }

        private static string GetSerialezeFromJson(DataActualization jsonObj)
        {
            return JsonConvert.SerializeObject(jsonObj);
        }

        /// <summary>
        /// Save Read Load method
        /// </summary>
        /// <param name="listBox"></param>
        public void RemodeAndRefreshListAct(ListBox listBox, ResultDefCode resultDefCode = null)
        {
            if (resultDefCode ==null)
            {
                Remove(FindDefCode(listBox.SelectedItem.ToString()));
            }
            else
            {
                Remove(resultDefCode);
            }

            SetSerializeFronJson();
            GetDeserializeFromJson();

            listBox.Items.Clear();
            foreach (var t in ShowDefCode())
            {
                listBox.Items.Add(t);
            }
        }

        public void SetSerializeFronJson()
        {
            using (StreamWriter write = new StreamWriter(jsonPath, false, Encoding.UTF8))
            {
                write.Write(GetSerialezeFromJson(dataActualization));
            }
        }

        public void Add(ResultDefCode addDefCode)
        {
            if (!dataActualization.ResultDefCodes.Exists((name) => name.DefCodeName == addDefCode.DefCodeName))
            {
                dataActualization.ResultDefCodes.Add(addDefCode);
            }
            else
            {
                MessageBox.Show($"[{addDefCode.DefCodeName}] дефкод уже есть в очереди");
            }
        }

        public void Remove(ResultDefCode removeDefCode)
        {
            if (dataActualization.ResultDefCodes.Exists((name) => name.DefCodeName == removeDefCode.DefCodeName))
            {
                dataActualization.ResultDefCodes.Remove(removeDefCode);
            }
            else
            {
                MessageBox.Show($"[{removeDefCode.DefCodeName}] дефкода нет в очереди");
            }
        }
        public ResultDefCode FindDefCode(string defcode)
        {
            return dataActualization.ResultDefCodes.FirstOrDefault((t) => defcode.Contains(t.DefCodeName));
        }

        public IEnumerable<string> ShowDefCode()
        {
            foreach (var t in dataActualization.ResultDefCodes)
            {
                yield return $"{t.DefCodeName} {t.CityName}  {t.OperatorName}";
            }
        }


        //public void Refresh(ComboBox operatorNames, ListBox listActualBox, string contains = " ")
        //{
        //    SetSerializeFronJson();

        //    Operator operatorName = (Operator)operatorNames.SelectedItem;
        //    contains = operatorName.Name;

        //    if (contains == "Не определено")
        //    {
        //        contains = " ";
        //    }

        //    listActualBox.Items.Clear();
        //    foreach (var t in ShowDefCode().Where((t) => t.Contains(contains)))
        //    {
        //        listActualBox.Items.Add(t);
        //    }
        // }
    }
}
