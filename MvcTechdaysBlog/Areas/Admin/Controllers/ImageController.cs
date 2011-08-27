using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTechdaysBlog.Areas.Admin.Models;
using MvcTechdaysBlog.Models;

namespace MvcTechdaysBlog.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private DataService db = new DataService();
        private string UploadFolder = "~/Uploads/";
        //
        // GET: /Admin/Image/

        public ViewResult Index()
        {
            return View(db.Images.ToList());
        }

        //
        // GET: /Admin/Image/Details/5

        public ViewResult Details(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // GET: /Admin/Image/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Image/Create

        [HttpPost]
        public ActionResult Create(CreateImageViewModel image)
        {
            if (ModelState.IsValid)
            {
                SaveFile(image);
                var imageToSave = new Image() { MIME = image.MIME, Id = image.Id, Title = image.Title, Url = image.Url };
                db.Images.Add(imageToSave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(image);
        }

        private void SaveFile(CreateImageViewModel image)
        {
            var fileName = image.HttpPostedFileBase.FileName.Split('\\').Last();
            image.Url = UploadFolder + fileName;
            image.MIME = image.HttpPostedFileBase.ContentType;
            var filePath = Server.MapPath(image.Url);

            using (var fileStream = new FileStream(filePath, FileMode.Truncate))
            {
                image.HttpPostedFileBase.InputStream.CopyTo(fileStream);
            }
        }

        //
        // GET: /Admin/Image/Edit/5

        public ActionResult Edit(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // POST: /Admin/Image/Edit/5

        [HttpPost]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        //
        // GET: /Admin/Image/Delete/5

        public ActionResult Delete(int id)
        {
            Image image = db.Images.Find(id);
            return View(image);
        }

        //
        // POST: /Admin/Image/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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