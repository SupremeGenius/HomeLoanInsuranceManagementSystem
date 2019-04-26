using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HLIMS.Entities;


namespace HLIMS.Services
{
    public class JSONSerializer
    {
        private static readonly JsonSerializerSettings _settings =
           new JsonSerializerSettings
           {
               Formatting = Formatting.Indented,
               TypeNameHandling = TypeNameHandling.Objects,
               ContractResolver = new CamelCasePropertyNamesContractResolver()
           };

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static List<Bank> DeserializeBankList(string data)
        {
            return JsonConvert.DeserializeObject<List<Bank>>(data, _settings);
        }
        public static List<Property> DeserializePropertyList(string data)
        {
            return JsonConvert.DeserializeObject<List<Property>>(data, _settings);
        }
    }
}