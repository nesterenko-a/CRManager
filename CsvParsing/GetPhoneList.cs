using CrmManager.CsvParsing.customList;
using CrmManager.CrmDB.QueryDB;

namespace CrmManager.CsvParsing
{
      class GetPhoneList
    {
       
        public AnswerClass answer;
        public NotAnswerClass no_answer;
        public SkippedClass skipped;

        public string[] files;
        public ResultDefCode resultDefCode;

        public GetPhoneList()
        {
            resultDefCode = new ResultDefCode();
        }

        public int GetCountPhoneInstance(FileName.TypeRu typeRu)
        {
            switch (typeRu) //Казань_Билайн_960-544_Ответ 
            {
                case FileName.TypeRu.Ответ: return answer.CountPhone();
                case FileName.TypeRu.Не_Ответ: return no_answer.CountPhone();
                case FileName.TypeRu.ПАС: return skipped.CountPhone();
                default: return answer.CountPhone() + no_answer.CountPhone() + skipped.CountPhone();
            }
        }

        //Ключ для Dictionary
        public string Show(FileName.TypeRu typeRu)
        {
          return resultDefCode.CityName + "_" + resultDefCode.OperatorName + "_" + resultDefCode.DefCodeName + "_" + typeRu.ToString() + "_" + GetCountPhoneInstance(typeRu);
        }
    }
}
