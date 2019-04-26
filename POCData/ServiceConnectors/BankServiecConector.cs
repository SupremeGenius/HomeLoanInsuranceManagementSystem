using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HLIMS.Entities;
using Newtonsoft.Json;

namespace HLIMS.Business.ServiceConnectors
{
    public class BankServiecConector : ServiceConnctorBase
    {
        public List<Bank> GetData()
        {
            List<Bank> data = new List<Bank>();
            HttpClient client = GetClient();
            client.BaseAddress = new Uri(BaseAddress);
            var responseTask = client.GetAsync("Bank");
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var jsonString = result.Content.ReadAsStringAsync();
                jsonString.Wait();
                data = JsonConvert.DeserializeObject<List<Bank>>(jsonString.Result);
            }
            responseTask.Wait();
            return data;
        }
        public void Create(Bank bank)
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(bank);
            Execute("Bank", json, ExecuteAction.Post);
        }
        public void Update(Bank bank)
        {
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(bank);
            Execute("Bank", json, ExecuteAction.Put);

        }
    }
}
