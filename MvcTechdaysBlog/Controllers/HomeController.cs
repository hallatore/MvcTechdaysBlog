using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTechdaysBlog.Filters;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Controllers
{
    [AllowAnonymous]
    public partial class HomeController : Controller
    {
        private DataService db = new DataService();

        public virtual ActionResult Index()
        {
            var articles = db.Articles.OrderBy(a => a.Date).ToList();
            return View(articles);
        }

        public virtual ActionResult Article(string id)
        {
            var article = db.Articles.SingleOrDefault(a => a.Url == id);

            if (article != null)
            {
                ViewBag.Comments = article.Comments.OrderByDescending(c => c.Date).ToList();
                return View(article);
            }
            
            throw new HttpException(404, "NotFound");
        }

        [HttpPost]
        public virtual ActionResult PostComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Now;
                db.Comments.Add(comment);
                db.SaveChanges();
            }

            return PartialView("Comment" ,comment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
