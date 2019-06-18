using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMVCApp.Models;

namespace BlogMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string q)
        {

            var model = db.Bloglar.Where(x => x.Onay == true && x.Anasayfa == true)
                .Select(x => new BlogModel()
                {
                    Anasayfa = x.Anasayfa,
                    Onay = x.Onay,
                    Aciklama = x.Aciklama,
                    EklenmeTarihi = x.EklenmeTarihi,
                    Resim = x.Resim,
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Baslik = x.Baslik.Length > 100 ? x.Baslik.Substring(0, 100) : x.Baslik
                }).AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                model = model.Where(x => x.Baslik.Contains(q) || x.Aciklama.Contains(q));
            }
            if (id != null)
            {
                return View(model.Where(x => x.CategoryId == id).ToList());
            }

            return View(model.ToList());
        }
        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category);
            return View(bloglar.OrderByDescending(x => x.EklenmeTarihi).ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            ModelState.Remove("Id");
            ModelState.Remove("EklenmeTarihi");
            ModelState.Remove("Onay");
            ModelState.Remove("Anasayfa");
            if (ModelState.IsValid)
            {
                blog.EklenmeTarihi = DateTime.Now;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            var entity = db.Bloglar.Find(blog.Id);
            if (ModelState.IsValid)
            {
                if (entity != null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.Id = blog.Id;
                    entity.Onay = blog.Onay;
                    entity.Resim = blog.Resim;
                    entity.CategoryId = blog.CategoryId;
                    db.SaveChanges();
                    TempData["blog"] = entity;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
