using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTechdaysBlog.Areas.Admin.Models;
using MvcTechdaysBlog.Helpers;

namespace MvcTechdaysBlog.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Admin/Account/

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model)
        {
            if (ModelState.IsValid && CheckCredentials(model))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("Index", "Article");                
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool CheckCredentials(LogOnViewModel model)
        {
            return Configuration.AdminUserName == model.UserName && Configuration.AdminPassword == model.Password;
        }
    }
}
