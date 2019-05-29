using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.CrmApi.Models
{
    /**
     * {
      "Data": [
    
      ],
      "Total": 1,
      "AggregateResults": null,
      "Errors": null
    }
    */
    public class CallBaseCreateModel
    {
        public CallBaseCreateDataModel[] Data;
        public int Total;
        public string AggregateResults;
        public string Errors;
    }
}
