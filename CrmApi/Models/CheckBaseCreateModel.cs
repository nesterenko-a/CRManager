using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmManager.CrmApi.Models
{
    public class CheckBaseCreateModel
    {
        public Datum[] Data { get; set; }
        public int Total { get; set; }
        public string AggregateResults { get; set; }
        public string Errors { get; set; }
    }

    public class Datum
    {
        public int Id;
        public int HashCode;
        //public int Id { get; set; }
        //public int HashCode { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public int CheckProject_Id { get; set; }
        //public int Provider_Id { get; set; }
        //public DateTime LoadDate { get; set; }
        //public int Capacity { get; set; }
        //public string StartNum { get; set; }
        //public string EndNum { get; set; }
        //public object NumbersFileName { get; set; }
        //public object NumbersFileData { get; set; }
        //public object NumbersFileContent { get; set; }
        //public bool IsActive { get; set; }
        //public bool HasNumbers { get; set; }
        //public bool IsCallBased { get; set; }
        //public bool IsCallLoadCallBaseAnswer { get; set; }
        //public bool IsCallLoadCallBaseReset { get; set; }
        //public bool IsCallLoadCallBasePAS { get; set; }
        //public bool CheckDoubles { get; set; }
        //public int CallProject_Id { get; set; }
    }
}
