using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Controllers
{
    public partial class CommentController : Controller
    {
        private DataService db = new DataService();

        //
        // GET: /Comment/

        public virtual ViewResult Index()
        {
            var comments = db.Comments.Include(c => c.Article);
            return View(comments.ToList());
        }

        //
        // GET: /Comment/Details/5

        public virtual ViewResult Details(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        //
        // GET: /Comment/Create

        public virtual ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title");
            return View();
        } 

        //
        // POST: /Comment/Create

        [HttpPost]
        public virtual ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comment.ArticleId);
            return View(comment);
        }
        
        //
        // GET: /Comment/Edit/5

        public virtual ActionResult Edit(int id)
        {
            Comment comment = db.Comments.Find(id);
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comment.ArticleId);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", comment.ArticleId);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5

        public virtual ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(int id)
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