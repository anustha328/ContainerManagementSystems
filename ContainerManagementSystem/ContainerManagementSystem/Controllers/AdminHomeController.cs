using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerManagementSystem.Models;
using Business.Business;
namespace ContainerManagementSystem.Controllers
{
    public class AdminHomeController : Controller
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
            var ds = bus.GetDropDownList();
            model.CountryNames = Library.Helper.SetDDLValue(ds.Tables[0], "", "Select Country");
        }
               
        public ActionResult DetailByID(int id)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();

            var detail = m.DetailByID(id);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            AdminHomeBusiness bus = new AdminHomeBusiness();
            var dbresult = bus.Delete(id);
            ModelState.AddModelError("Error", dbresult.Message);
            return RedirectToAction("Index");

        }

        public ActionResult AdminHomeContainer()
        {
            AdminHomeBusiness m = new AdminHomeBusiness();

            var list = m.AdminnHomeContainer();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchContainer(string SearchItem)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.SearchContainer(SearchItem);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

         [HttpPost]
        public ActionResult save(AdminHomeModel model)

        {
            try
            {
                AdminHomeBusiness bus = new AdminHomeBusiness();
                var common = new Common.Common.AdminHomeCommon();
                common.ContainerID = model.ContainerID;
                common.Country = model.Country;
                common.ContainerName = model.ContainerName;
                
                var result = bus.save(common);
                if (result.ErrorCode == "0")
                {
                    TempData["Success"] = result.Message;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Error", result.Message);
                return View("Index",model);
            }
            catch
            {
                return View("Index");
            }
        }
    }

}
