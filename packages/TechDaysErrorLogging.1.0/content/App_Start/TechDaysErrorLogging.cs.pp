using System.Web.Mvc;
using TechDaysErrorLogging;

[assembly: WebActivator.PostApplicationStartMethod(typeof($rootnamespace$.App_Start.TechDaysErrorLogging), "Start")]
namespace $rootnamespace$.App_Start
{
    public class TechDaysErrorLogging
    {
        public static void Start()
        {
            GlobalFilters.Filters.Add(new TechDaysErrorLoggerAttribute());
        }
    }
}