using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerManagementSystem.Models;
using Business.Business;
namespace ContainerManagementSystem.Controllers
{
    public class AdminCountryController : Controller
    {
        string message;
        public ActionResult Index()
        {
            AdminHomeModel model = new AdminHomeModel();
            Dropdown(model);
            ViewData["Error"] = message;

            return View(model);


        }
        private void Dropdown(AdminHomeModel model)
        {
            AdminHomeBusiness bus = new AdminHomeBusiness();
            var ds = bus.GetDropDownList1();
            model.ContinentName = Library.Helper.SetDDLValue(ds.Tables[0], "", "Select Continent");
        }


        public ActionResult SearchShipment(string SearchItem)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();

            var detail = m.SearchShipment(SearchItem);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CountryDetailByID(int id)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();

            var detail = m.CountryDetailByID(id);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            AdminHomeBusiness bus = new AdminHomeBusiness();
            var dbresult = bus.CountryDelete(id);
            ModelState.AddModelError("Error", dbresult.Message);
            return RedirectToAction("Index");

        }

        public ActionResult AdminCountry()
        {
            AdminHomeBusiness m = new AdminHomeBusiness();

            var list = m.AdminHomeCountry();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchCountry(string CountryName)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.SearchCountry(CountryName);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Countrysave(AdminHomeModel model)

        {
            try
            {
                AdminHomeBusiness bus = new AdminHomeBusiness();
                var common = new Common.Common.AdminHomeCommon();
                common.CountryID = model.CountryID;
                common.CountryName = model.CountryName;
                common.Continent = model.Continent;

                var result = bus.countrysave(common);
                if (result.ErrorCode == "0")
                {
                    TempData["Success"] = result.Message;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Error", result.Message);
                return View("Index", model);
            }
            catch
            {
                return View("Index");
            }
        }
    }

}
