using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVCApp.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            List<Category> kategoriler = new List<Category>
            {
                new Category{KategoriAdi="C#"},
                new Category{KategoriAdi="Asp.Net MVC"},
                new Category{KategoriAdi="Asp.Net WebForm"},
                new Category{KategoriAdi="Windows Form"},
                new Category{KategoriAdi="Asp.Net Core MVC"}
            };
            foreach (Category category in kategoriler)
            {
                context.Kategoriler.Add(category);
            }
            context.SaveChanges();
            List<Blog> bloglar = new List<Blog>
            {
                new Blog{Baslik="C# Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="1.jpg",EklenmeTarihi=DateTime.Now.AddDays(-10),CategoryId=1,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="Asp.Net MVC Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="2.jpg",EklenmeTarihi=DateTime.Now.AddDays(-9),CategoryId=2,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="Asp.Net WebForm Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="3.jpg",EklenmeTarihi=DateTime.Now.AddDays(-8),CategoryId=3,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="Windows Form Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="4.jpg",EklenmeTarihi=DateTime.Now.AddDays(-7),CategoryId=4,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="Asp.Net Core MVC Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="5.jpg",EklenmeTarihi=DateTime.Now.AddDays(-6),CategoryId=5,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="22C# Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="6.jpg",EklenmeTarihi=DateTime.Now.AddDays(-20),CategoryId=1,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="33Asp.Net MVC Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="7.jpg",EklenmeTarihi=DateTime.Now.AddDays(-19),CategoryId=2,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="44Asp.Net WebForm Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="8.jpg",EklenmeTarihi=DateTime.Now.AddDays(-18),CategoryId=3,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="55Windows Form Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="9.jpg",EklenmeTarihi=DateTime.Now.AddDays(-17),CategoryId=4,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"},
                new Blog{Baslik="66Asp.Net Core MVC Delegetes Hakkında",Aciklama="Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.",Anasayfa=true,Onay=true,Resim="10.jpg",EklenmeTarihi=DateTime.Now.AddDays(-16),CategoryId=5,Icerik="Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık"}
            };

            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}