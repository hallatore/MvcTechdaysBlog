using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronRuby.Builtins;
using MvcTechdaysBlog.Filters;

namespace MvcTechdaysBlog.Controllers
{
    [AllowAnonymous]
    public partial class ErrorController : Controller
    {
        public virtual ActionResult Error1()
        {
            throw new ArgumentException("hey ho... you have some argument issues!");
        }
        public virtual ActionResult Error2()
        {
            throw new ApplicationException("hey ho... you have some serious issues!");
        }
    }
}
