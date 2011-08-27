using System;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace MvcTechdaysBlog
{
    public class TechdaysBlogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            if (filterContext.Exception.GetType() ==  typeof(ArgumentException))
            {
                View = "Error2";
            }
            else
            {
                View = "Error";
            }
            LogException(exception);
            base.OnException(filterContext);    
        }

        private void LogException(Exception exception)
        {
            var filePath = HostingEnvironment.MapPath("~/Logs/Error.log");
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }
                using (fileInfo.Create())
                {
                }
            }
            using (var textWriter = fileInfo.AppendText())
            {
                textWriter.WriteLine("{0} Error: {1}", DateTime.Now, exception.Message);
                textWriter.WriteLine("===> Stack trace: {0}", exception.ToString());
            }
        }
    }
}