using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContainerManagementSystem.Models;
using Business.Business;

namespace ContainerManagementSystem.Views.Register
{
    public class RegisterController : Controller
    {
        // GET: Register
        string message;
     
      
        public ActionResult Index()
        {
           return View();
        }


        [HttpPost]
        public ActionResult Save(LogInModel model)

        {
            try
            {
                LogInBusiness bus = new LogInBusiness();
                var common = new Common.Common.LogInCommon();
                common.UserID = model.UserID;
                common.Name = model.Name;
                common.ContactNo = model.ContactNo;
                common.Email = model.Email;
                common.Username = model.Username;
                common.Password = model.Password;
                common.ConfirmPassword = model.ConfirmPassword;

                var result = bus.Save(common);
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