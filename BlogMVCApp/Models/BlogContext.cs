using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("BlogVt")
        {
            Database.SetInitializer(new BlogInitializer());
        }


        public DbSet<Category> Kategoriler { get; set; }
        public DbSet<Blog> Bloglar { get; set; }

    }
}