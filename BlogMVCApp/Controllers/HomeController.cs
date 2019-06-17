﻿using BlogMVCApp.Models;
using System;
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
            return View(context.Bloglar.ToList());
        }
    }
}