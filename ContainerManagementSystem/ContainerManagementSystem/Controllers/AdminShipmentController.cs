﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Business;
using ContainerManagementSystem.Models;

namespace ContainerManagementSystem.Controllers
{
    public class AdminShipmentController:Controller
    {
        public ActionResult Index()
        {
            return View();


        }

        public ActionResult ViewShipment()
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.ViewShipment();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchShipment(string SearchItem)
        {
            AdminHomeBusiness m = new AdminHomeBusiness();
            var list = m.SearchShipment(SearchItem);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}