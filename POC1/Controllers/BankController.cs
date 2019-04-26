using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POCData;
using POCCommon;
using System.Net.Http;

namespace POC1.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
            {
            ViewModelBase mgr = new BankViewModel();
            return View(mgr);
        }

        [HttpPost]
        public ActionResult Index(BankViewModel vm)
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
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
