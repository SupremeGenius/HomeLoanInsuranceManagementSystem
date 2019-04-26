using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POCData;
using POCCommon;

namespace POC1.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            ViewModelBase mgr = new LoanViewModel();
            return View(mgr);
        }
    }
}