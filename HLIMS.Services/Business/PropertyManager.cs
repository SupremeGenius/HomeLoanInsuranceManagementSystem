using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HLIMS.Entities;
namespace HLIMS.Services.Business
{
    public class PropertyManager
    {
        public IList<Property> GetPropertyList()
        {
            IList<Property> data = getFromCache();
            if (data== null || data.Count==0)
            {
                data = getPropertyData();
                updateCache(data);
            }
            return data;
        }
        public void InsertPropertyData(Property property)
        {
            using (var ctx = new HLIMSYSTEMEntities())
            {
              ctx.tblProperties.Add(new tblProperty()
                {
                    Type = Convert.ToInt32(property.PropertyType.Value),
                    Address = property.Address
                });
                ctx.SaveChanges();
                IList<Property> propList = getPropertyData();
                updateCache(propList);
            }
        }
        public void UpdatePropertyData(Property property)
        {
            using (var ctx = new HLIMSYSTEMEntities())
            {
                ctx.tblProperties.Add(new tblProperty()
                {
                    Type = Convert.ToInt32(property.PropertyType.Value),
                    Address = property.Address
                });
                ctx.SaveChanges();

                IList<Property> propList = getPropertyData();
                updateCache(propList);
            }
        }
        private IList<Property> getPropertyData()
        {
            IList<Property> data = null;
            using (var ctx = new HLIMSYSTEMEntities())
            {
                data = ctx.tblProperties.Select(s => new Property()
                {
                    Id = s.Id,
                    PropertyType = s.Type == 1 ? PropertyType.Apartment : PropertyType.House,
                    Address = s.Address
                }).ToList<Property>();
            }
            return data;
        }
        private void updateCache(IList<Property> data)
        {
            var cache = CacheManager.Connection.GetDatabase();
            var objectString = cache.StringGet(@"PROPERTY_CACHE");
            objectString = JSONSerializer.Serialize(data);
            cache.StringSet(@"PROPERTY_CACHE", objectString);

        }
        private IList<Property> getFromCache()
        {
            IList<Property> data = null;
            var cache = CacheManager.Connection.GetDatabase();
            var objectString = cache.StringGet(@"PROPERTY_CACHE");

            if (!objectString.IsNullOrEmpty)
            {
                data = JSONSerializer.DeserializePropertyList(objectString);
            }
            return data;
        }
	}
}