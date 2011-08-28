using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Areas.Admin.Controllers
{ 
    public class ArticleController : Controller
    {
        private DataService db = new DataService();

        //
        // GET: /Admin/Article/

        public ViewResult Index()
        {
            return View(db.Articles.ToList());
        }

        //
        // GET: /Admin/Article/Details/5

        public ViewResult Details(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // GET: /Admin/Article/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Article/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(article);
        }
        
        //
        // GET: /Admin/Article/Edit/5
 
        public ActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // POST: /Admin/Article/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Admin/Article/Delete/5
 
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // POST: /Admin/Article/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult UniqueUrlCheck(string url)
        {
            var urlExists = db.Articles.Any(y => y.Url.ToLower() == url.ToLower());
            if (urlExists)
            {
                return Json("URL already exists", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}