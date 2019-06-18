using BlogMVCApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCApp.Controllers
{
    public class HomeController : Controller
    {
        BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var model = context.Bloglar
                .Select(x => new BlogModel()
                {
                    Anasayfa = x.Anasayfa,
                    Onay = x.Onay,
                    Aciklama = x.Aciklama,
                    EklenmeTarihi = x.EklenmeTarihi,
                    Resim = x.Resim,
                    Id = x.Id,
                    Baslik = x.Baslik.Length > 100 ? x.Baslik.Substring(0, 100) : x.Baslik
                })
                .Where(x => x.Onay == true && x.Anasayfa == true);

            return View(model.ToList());
        }
    }
}