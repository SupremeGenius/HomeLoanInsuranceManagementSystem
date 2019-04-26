using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLIMSEntity;

using HLIMS.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace POCData
{
    public class PropertyUOW : 
                IActionManager, IPropertyRepository
    {
        public List<KeyValuePair<string, string>> validationError
        {
            get;
            set;
        }
        public PropertyUOW()
        {
            validationError = new List<KeyValuePair<string, string>>();
        }

        public bool Validate(BaseEntity entity)
        {
            Property property = entity as Property;
            validationError.Clear();
            if (string.IsNullOrEmpty(property.Address))
            {
                if (property.Address.ToLower() == property.Address)
                {
                    validationError.Add(new KeyValuePair<string, string>("PropertyAddress", "Property Address must not be all in Lower case"));
                }
            }
            return (validationError.Count == 0);

        }

        public List<Property> Get(Property entity)
        {
            List<Property> returnData = new List<Property>();
            returnData = getData();

            if (entity != null && !string.IsNullOrEmpty(entity.Address))
            {
                returnData = returnData.FindAll(p => p.Address.ToLower().StartsWith(
                    entity.Address.ToLower()));
            }
            return returnData;
        }
        public Property Get(int Id)
        {
            List<Property> list = new List<Property>();
            Property returnProduct = new Property();
            list = getData();
            returnProduct = list.Find(p => p.Id == Id);
            return returnProduct;
        }

        public bool Insert(BaseEntity entity)
        {
            Property  property = entity as Property;
            bool ret = false;
            ret = Validate(property);
            if (ret)
            {
                //Create Insert Statement
                createData(property);
            }
            return ret;

        }

        public bool Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Property entity)
        {
            bool returnValue = false;
            var returnData = Validate(entity);
            if (returnData)
            {
                //Crete the update Code
                updateData(entity);
            }
            return returnValue;
        }
        private List<Property> getData()
        {
            List<Property> data = new List<Property>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var responseTask = client.GetAsync("Property");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    data = JsonConvert.DeserializeObject<List<Property>>(jsonString.Result);
                }
                responseTask.Wait();
            }
            return data;
        }

        private bool createData(Property property)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(property);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("Property", stringContent).Result;
            }
            return true;
        }
        private bool updateData(Property Property)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:25383/api/");
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(Property);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PutAsync("Property", stringContent).Result;
            }
            return true;
        }

    }
}
