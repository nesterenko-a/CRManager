using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmManager.CrmDB.QueryDB;

namespace CrmManager.CrmDB
{
    public enum SearchThis
    {
        Yes,
        No        
    }

    public class Logic
    {
        public static Model1 db;
        private Logger logger;

        public static ResultDefCode operatorFromDefCode;
        private static List<Operator> mobileOperator = null;
        private static List<City> cityes = null;
          
        public Logic()
        {
            db = new Model1();
            operatorFromDefCode = new ResultDefCode();
        }

        public static void RefreshList()
        {
            mobileOperator = null;
            cityes = null;
        }

        public void SetLogger(Logger logger)
        {
            this.logger = logger;
        }

        #region GetUniqueOperator
        //public Operator GetCurrentOperator()
        //{
        //    Operator sotOperator = db
        //        .Operators
        //        .Where(g => g.Name == "Билайн")
        //        .OrderBy(g => g.id_operator)
        //        .FirstOrDefault();
        //    if (sotOperator == null)
        //        return null;  //Searth dont find
        //    return sotOperator;

        //}
        #endregion

        #region GetUniqueDefCode
        public async Task<SearchThis> GetSearthDefCode(string name)//, EnumYesNo.YesNo yesNo)
        {
            DefCode defCode = new DefCode();

            await Task.Run(() =>
            {
                defCode = db
               .DefCodes
               .Where(g => g.Name == name)
               .FirstOrDefault();
            });
           

            if (defCode == null)
            {
                logger.Log("Don't find: " + name);
                return SearchThis.No;
            }

            logger.Log(name + " find");   
            return SearchThis.Yes;

        }
        #endregion

        public static List<Operator> GetOperatorList()
        {
            if (mobileOperator == null)
            {
                try
                {
                    IQueryable<Operator> query = db.Operators;
                    mobileOperator = query.ToList();
                    //  List<Operator> customers = db.Operators.Where(c => c.id_operator == 1).ToList(); //или так вместо верхних 2ух строк. 
                    //logger.Log("Successful GetOperatorList");
                    return mobileOperator;
                }

                catch
                {
                    //logger.Log("Error GetOperatorList" + ex);
                    return null;
                }
            }
            else
                return mobileOperator;
        }

        public static List<City> GetCityList()
        {
            if (cityes == null)
            {
                try
                {
                    IQueryable<City> query = db.Cities;
                    cityes = query.ToList();
                    //  List<Operator> customers = db.Operators.Where(c => c.id_operator == 1).ToList(); //или так вместо верхних 2ух строк. 
                  //  logger.Log("Successful GetOperatorList");
                    return cityes;
                }

                catch
                {
                   // logger.Log("Error GetOperatorList" + ex);
                    return null;
                }
            }
            else
            {
                return cityes;
            }
        }

        public static Task<ResultDefCode> GetOpetatorFromDefAsync(string defCode) //TODO Получить все данные по Номеру Дефкода 960-334
        {
            return Task.FromResult(GetOpetatorFromDef(defCode));
        }

        /// <summary>
        /// Поиск по DefCode
        /// </summary>
        /// <param name="defCode">960-433</param>
        /// <returns>List<FindResultDefCode></returns>
        public static ResultDefCode GetOpetatorFromDef(string defCode) //TODO Получить все данные по Номеру Дефкода 960-334
        {
            #region DefCodeInformation
            var transactions = from dc in db.DefCodes
                               join op in db.Operators on dc.id_operator equals op.id_operator
                               join ct in db.Cities on dc.id_city equals ct.id_city
                               where dc.Name == defCode

                               select new ResultDefCode
                               {
                                   OperatorName = op.Name,
                                   OperatorIdName = op.id_crm_operator,

                                   DefCodeName = dc.Name,

                                   CityName = ct.Name,
                                   CityIdName = ct.id_crm_city
                               };
            #endregion

            if (transactions.Count() > 1)
            {
                //logger.Log("Найдены дубликаты ДефКодов!!!");
                return null;
            }

            var resultProfit = new ResultDefCode();

            foreach (var result in transactions)
            {
                resultProfit = GetResak(result.CityName, result.CityIdName, result.DefCodeName, result.OperatorName, result.OperatorIdName);
            }
            return resultProfit;
        }

        private static ResultDefCode GetResak(string CityName, long  CityIdName, string DefCodeName, string OperatorName, long OperatorIdName)
        {
            return new ResultDefCode() { CityName = CityName, CityIdName = CityIdName, DefCodeName = DefCodeName,
                                                    OperatorName = OperatorName, OperatorIdName = OperatorIdName };
        }

        /// <summary>
        /// Добавление нового оператора
        /// </summary>
        /// <param name="OperatorName">Имя сотового оператора</param>
        /// <param name="OperatorIdName">ID в CRM</param>
        /// <returns>Operator</returns>
        public async Task AddOperatorAsync(string OperatorName, long OperatorIdName)
        {
            if (!string.IsNullOrEmpty(OperatorName) && OperatorName != null)
            {
                try
                {
                    Operator sotOperator = new Operator
                    {
                        id_crm_operator = OperatorIdName,
                        Name = OperatorName
                    };
                    db.Operators.Add(sotOperator);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    logger.Log("Error " + ex);
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(OperatorName)} or {nameof(OperatorIdName)} is empty.");
            }

        }

        private int GetIDMobileOperator(string operatorName)
        {
            Operator operatorFind = db
               .Operators
               .Where(g => g.Name == operatorName)
               .FirstOrDefault();
            if (operatorFind == null)
            {
                logger.Log("Don't find: " + operatorName);
                return 0;
            }
            return (int)operatorFind.id_operator;
        }

        private int GetIDCityOperator(string cityName)
        {
            City city = db
                .Cities
                .Where(g => g.Name == cityName)
                .FirstOrDefault();
            if (city == null)
            {
                logger.Log("Don't find: " + cityName);
                return 0;
            }
            return city.id_city;
        }

        public async Task AddDefCodeAsync(string cityName, string operatorName, string mobileDefCode)
        {
            if (cityName != null & operatorName != null & mobileDefCode != "   -")
                if (await GetSearthDefCode(mobileDefCode) == SearchThis.No)
                {
                    try
                    {
                        DefCode defCode = new DefCode
                        {
                            id_city = GetIDCityOperator(cityName),
                            id_operator = GetIDMobileOperator(operatorName),
                            Name = mobileDefCode
                        };
                        db.DefCodes.Add(defCode);
                        await db.SaveChangesAsync();
                        logger.Log(cityName + " " + operatorName + " " + mobileDefCode + " add in base");
                    }
                    catch (Exception ex)
                    {
                        logger.Log("Error " + ex);
                    }
                }
                else logger.Log(mobileDefCode + " defcode already in base");
            else
            {
                throw new ArgumentException($"{nameof(cityName)} or {nameof(operatorName)} or {nameof(mobileDefCode)} is empty!");
            }
        }

        public async Task AddDefCodeAsync(string cityName, string operatorName, IEnumerable<string> mobileDefCodes)
        {
            foreach(var item in mobileDefCodes)
            {
                await AddDefCodeAsync(cityName, operatorName, item);
            }

        }
    }
}
