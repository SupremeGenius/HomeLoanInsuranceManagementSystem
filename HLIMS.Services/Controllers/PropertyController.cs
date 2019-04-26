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
            return Ok();
        }
    }
}
