using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Linq;

namespace MvcTechdaysBlog.Controllers
{
    public class ValidationController : Controller
    {
        public JsonResult BadWords(string content)
        {
            var badWords = new[] { "java", "oracle", "webforms" };
            if (CheckText(content, badWords))
            {
                return Json("Sorry, you can't use java, oracle or webforms!", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private bool CheckText(string content, string[] badWords)
        {
            foreach (var badWord in badWords)
            {
                var regex = new Regex("(^|[\\?\\.,\\s])" + badWord + "([\\?\\.,\\s]|$)");
                if (regex.IsMatch(content)) return true;
            }
            return false;
        }
    }
}