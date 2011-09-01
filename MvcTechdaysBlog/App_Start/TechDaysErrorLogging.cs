using System.Web.Mvc;
using TechDaysErrorLogging;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MvcTechdaysBlog.App_Start.TechDaysErrorLogging), "Start")]
namespace MvcTechdaysBlog.App_Start
{
    public class TechDaysErrorLogging
    {
        public static void Start()
        {
            GlobalFilters.Filters.Add(new TechDaysErrorLoggerAttribute());
        }
    }
}