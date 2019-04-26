using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POCData;
using POCCommon;

namespace POC1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewModelBase mgr = new TrainingProductViewModel();
            //mgr.Get();
            return View(mgr);
        }
        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                if (vm.ValidationErrors != null)
                {
                    foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }
                }

            }

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}