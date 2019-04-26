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
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var responseTask = client.GetAsync("Bank");
                
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    data = JsonConvert.DeserializeObject<List<Bank>>(jsonString.Result);
                }
                responseTask.Wait();
            }
            return data;
        }
        private bool createBank(Bank bank)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(bank);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("Bank",stringContent).Result;
            }
            return true;
        }
        private bool updateBank(Bank bank)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(bank);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PutAsync("Bank", stringContent).Result;
            }
            return true;
        }
        public bool Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
