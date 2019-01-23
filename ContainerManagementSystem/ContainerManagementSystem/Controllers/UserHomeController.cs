using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerManagementSystem.Models;
using Business.Business;
namespace ContainerManagementSystem.Controllers
{
    public class UserHomeController:Controller
    {
        string message;
        public ActionResult Index(int ID)
        {
            TempData["ID"] = ID;
            UserHomeModel model = new UserHomeModel();
            Dropdown(model);
            Dropdownlist(model);
            ViewData["Error"] = message;

            return View(model);
            
            
        }
        private void Dropdown(UserHomeModel model)
        {
            UserHomeBusiness bus = new UserHomeBusiness();
            var ds = bus.GetDropDownList();
            model.Departure = Library.Helper.SetDDLValue(ds.Tables[0], "", "Select Country");
        }

        private void Dropdownlist(UserHomeModel model)
        {
            UserHomeBusiness bus = new UserHomeBusiness();
            var ds = bus.GetDropDownList1();
            model.Destination = Library.Helper.SetDDLValue(ds.Tables[0], "", "Select Country");
        }

        public ActionResult DetailByID(int id)
        {
            UserHomeBusiness m = new UserHomeBusiness();

            var detail = m.DetailByID(id);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserHomeContainer()
        {
            UserHomeBusiness m = new UserHomeBusiness();

            var list = m.UserHomeContainer();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchContainer(string SearchItem)
        {
            UserHomeBusiness m = new UserHomeBusiness();
            var list = m.SearchContainer(SearchItem);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewShipment(string UserID)
        {
            UserHomeBusiness m = new UserHomeBusiness();
            var list = m.ViewShipment(UserID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult save(UserHomeModel model)

        {
            try
            {
                UserHomeBusiness bus = new UserHomeBusiness();
                var common = new Common.Common.UserHomeCommon();
                common.UserID = model.UserID;
                common.ContainerID = model.ContainerID;
                common.DepartureFrom = model.DepartureFrom;
                common.ArrivalTO = model.ArrivalTO;
                common.DepartureDate = model.DepartureDate;
                common.ArrivalDate = model.ArrivalDate;
                
                var result = bus.save(common);
                if (result.ErrorCode == "0")
                {
                    TempData["Success"] = result.Message;
                    string url = string.Format("/UserHome/index?ID="+model.UserID);
                       return Redirect(url);
                }
                ModelState.AddModelError("Error", result.Message);
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }

}
