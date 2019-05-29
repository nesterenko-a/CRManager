using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.CrmApi.Models
{
    /**
     * {
      "Id": 25199,
      "HashCode": 845874386,
      "Name": "test bad",
      "Description": null,
      "CallProject_Id": 55,
      "Provider_Id": 13,
      "LoadDate": "\\/Date(1521056268678)\\/",
      "IsActive": false,
      "Capacity": 0,
      "Counter": 0,
      "CounterPercent": 0,
      "NumbersFileName": "phone_test_load-bad.txt",
      "NumbersFileData": null,
      "NumbersFileContent": "gh fg hfgh g\r\n fh\r\nf\r\n h\r\nft\r\n h\r\nf h\r\n t",
      "CheckDoubles": false,
      "LastAssignDate": null,
      "ShortCallsAutoDeActivationTime": null
    }*/

    public class CallBaseCreateDataModel
    {
        public int Id;
        public int HashCode;
    }
}
