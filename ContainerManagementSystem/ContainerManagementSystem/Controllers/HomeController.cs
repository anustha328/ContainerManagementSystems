using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Business;
using ContainerManagementSystem.Models;


namespace ContainerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        string message;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(string Username, string Password)
        {
            LogInBusiness m = new LogInBusiness();

            var detail = m.LogIn(Username, Password);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }


    }
}