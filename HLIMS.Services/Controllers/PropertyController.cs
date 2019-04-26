using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HLIMS.Entities;
using HLIMS.Services.Business;

namespace HLIMS.Services.Controllers
{
    public class PropertyController : ApiController
    {
        public IHttpActionResult Get()
        {
            PropertyManager manager = new PropertyManager();
            IList<Property> data = manager.GetPropertyList();
            //using (var ctx = new HLIMSYSTEMEntities())
            //{
            //    data = ctx.tblProperties.Select(s => new Property()
            //    {
            //        Id = s.Id,
            //        PropertyType= s.Type==1?PropertyType.Apartment:PropertyType.House,
            //        Address = s.Address
            //    }).ToList<Property>();
            //}

            if (data.Count == 0)
            {
                return NotFound();
            }
            return Ok(data);
        }
        public IHttpActionResult Post(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            PropertyManager manager = new PropertyManager();
            manager.InsertPropertyData(property);
            //using (var ctx = new HLIMSYSTEMEntities())
            //{
            //    ctx.tblProperties.Add(new tblProperty()
            //    {
            //        Type= Convert.ToInt32(property.PropertyType.Value),
            //        Address= property.Address
            //    });
            //    ctx.SaveChanges();
            //}
            return Ok();
        }
        public IHttpActionResult Put(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            PropertyManager manager = new PropertyManager();
            manager.UpdatePropertyData(property);
            //using (var ctx = new HLIMSYSTEMEntities())
            //{
            //    var data = ctx.tblProperties.First<tblProperty>();
            //    data.Type= Convert.ToInt32(property.PropertyType.Value);
            //    data.Address = property.Address;
            //    ctx.SaveChanges();
            //}
            return Ok();
        }
    }
}
