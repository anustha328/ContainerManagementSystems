using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Business;
using ContainerManagementSystem.Models;

namespace ContainerManagementSystem.Controllers
{
    public class AdminUserController : Controller
    {
        public ActionResult Index()
        {
            return View();


        }

        public ActionResult ViewUsert()
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.ViewUser();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchUser(string SearchItem)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.SearchUser(SearchItem);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}