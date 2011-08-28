using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Areas.Admin.Controllers
{ 
    public class CommentController : Controller
    {
        private DataService db = new DataService();

        public ViewResult Index()
        {
            var comments = db.Comments.Include(c => c.Article);
            return View(comments.ToList());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}