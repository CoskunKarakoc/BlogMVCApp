using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMVCApp.Models;

namespace BlogMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            var model = db.Kategoriler.Select(i => new CategoryViewModel
            {

                Category = i,
                BlogSayisi = i.Bloglar.Count

            });



            return View(model.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var kategori = db.Kategoriler.Find(category.Id);
                if (kategori != null)
                {
                    kategori.Id = category.Id;
                    kategori.KategoriAdi = category.KategoriAdi;
                }

                db.SaveChanges();
                TempData["kategori"] = kategori;
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Kategoriler.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriListesi()
        {
            return PartialView("_PartialKategoriListesi",db.Kategoriler.ToList());
        }


    }
}
