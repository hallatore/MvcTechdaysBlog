using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcTechdaysBlog.Filters;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TechdaysBlogErrorAttribute());
            filters.Add(new RequireAutheticationAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Article",
                "{url}",
                new { controller = "Article", action = "Details" },
                new string[] { "MvcTechdaysBlog.Controllers" }
                );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { "MvcTechdaysBlog.Controllers" }
                );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
//            Database.SetInitializer(new DataServiceInit());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class DataServiceInit : DropCreateDatabaseAlways<DataService>
    {
        protected override void Seed(DataService context)
        {
            base.Seed(context);
        }
    }
}