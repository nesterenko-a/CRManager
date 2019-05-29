using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmManager.CrmDB;

namespace CrmManager.CrmDB.QueryDB
{
    public class ResultDefCode
    {
        public string OperatorName;
        public long OperatorIdName;

        public string CityName;
        public long CityIdName;

        public string DefCodeName; 
    }

    public class DataActualization
    {
        public List<ResultDefCode> ResultDefCodes;

        public DataActualization()
        {
            ResultDefCodes = new List<ResultDefCode>();           
        }
    }

}
