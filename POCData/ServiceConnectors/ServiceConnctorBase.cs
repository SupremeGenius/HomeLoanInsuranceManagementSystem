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
    public enum ExecuteAction
    {
        Post=1,
        Put=2
    }

    public abstract class ServiceConnctorBase
    {
        public ServiceConnctorBase(){}
        public HttpClient GetClient()
        {
           var client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            return client;   
        }
        public virtual void Execute(string uri, string json, ExecuteAction action)
        {
            HttpClient client = GetClient();
            client.BaseAddress = new Uri(BaseAddress);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            if (action == ExecuteAction.Post)
            {
                var postTask = client.PostAsync(uri, stringContent).Result;
            }
            else
            {
                var postTask = client.PutAsync(uri, stringContent).Result;
            }
        }
        
        public static void HandleException()
        {
            HandleException();
        }
        public const string BaseAddress = "http://localhost:25383/api/";
    }

   
}
