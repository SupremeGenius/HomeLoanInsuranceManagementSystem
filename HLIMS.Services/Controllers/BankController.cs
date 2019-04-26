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
    public class BankController : ApiController
    {
        public IHttpActionResult Get()
        {
            BankManager manager = new BankManager();
            IList<Bank> data =manager.GetBankList();
            if (data.Count == 0)
            {
                return NotFound();
            }
            return Ok(data);
        }
        public IHttpActionResult Post(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            BankManager manager = new BankManager();
            manager.InsertBankData(bank);
            return Ok();
        }
        public IHttpActionResult Put(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            BankManager manager = new BankManager();
            manager.UpdateBankData(bank);
            return Ok();
        }
    }
}
