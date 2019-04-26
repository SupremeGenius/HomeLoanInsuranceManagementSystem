using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
//using HLIMSEntity;

using HLIMS.Entities;
using Newtonsoft.Json;
using HLIMS.Business.ServiceConnectors;

namespace POCData
{
    public class BankUOW :IActionManager, IBankRepository
    {
        public List<KeyValuePair<string, string>> validationError
        {
            get;
            set;
        }

        public BankUOW()
        {
            validationError = new List<KeyValuePair<string, string>>();

        }
        public bool Validate(BaseEntity entity)
        {
            Bank bank = entity as HLIMS.Entities.Bank;
            validationError.Clear();
            if (string.IsNullOrEmpty(bank.Name))
            {
                if (bank.Name.ToLower() == bank.Name)
                {
                    validationError.Add(new KeyValuePair<string, string>("BankName", "Bank Name must not be all in Lower case"));
                }
            }
            return (validationError.Count == 0);

        }
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(BaseEntity entity)
        {
            Bank bank = entity as Bank;

            bool ret = false;
            ret = Validate(entity);
            if (ret)
            {
                createBank(bank);
            }
            return ret;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<Bank> Get(Bank entity)
        {
            List<Bank> returnData = new List<Bank>();
            returnData = getData();
            if (entity != null && !string.IsNullOrEmpty(entity.Name))
            {
                returnData = returnData.FindAll(p => p.Name.ToLower().StartsWith(
                    entity.Name.ToLower()));
            }
            return returnData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Bank Get(int productId)
        {
            List<Bank> list = new List<Bank>();
            Bank returnProduct = new Bank();
            list = getData();
            returnProduct = list.Find(p => p.Id== productId);
            return returnProduct;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(Bank entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnData)
            {
                updateBank(entity);
            }
            return returnValue;
        }

        private List<Bank> getData()
        {
            List<Bank> data = new List<Bank>();
            BankServiecConector service = new BankServiecConector();
            data = service.GetData();
            return data;
        }
        private bool createBank(Bank bank)
        {
            BankServiecConector service = new BankServiecConector();
            service.Create(bank);
            return true;
        }
        private bool updateBank(Bank bank)
        {
            BankServiecConector service = new BankServiecConector();
            service.Update(bank);
            return true;
        }
        public bool Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
