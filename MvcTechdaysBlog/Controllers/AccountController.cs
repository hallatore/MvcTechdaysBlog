﻿using System.Web.Mvc;
using System.Web.Security;
using MvcTechdaysBlog.Areas.Admin.Models;
using MvcTechdaysBlog.Filters;
using MvcTechdaysBlog.Helpers;

namespace MvcTechdaysBlog.Controllers
{
    public partial class AccountController : Controller
    {
        //
        // GET: /Admin/Account/

        [AllowAnonymous]
        public virtual ActionResult LogOn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Article");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual ActionResult LogOn(LogOnViewModel model)
        {
            if (ModelState.IsValid && CheckCredentials(model))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                var redirectUrl = FormsAuthentication.GetRedirectUrl(model.UserName, false);
                if (string.IsNullOrEmpty(redirectUrl))
                {
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    return Redirect(redirectUrl);
                }
            }
            return View(model);
        }

        public virtual ActionResult LogOff()
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
