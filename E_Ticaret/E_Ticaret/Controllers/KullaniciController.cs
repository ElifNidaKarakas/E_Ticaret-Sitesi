using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models;



namespace E_Ticaret.Controllers
{
    public class KullaniciController : Controller
    {
        Entities1 db = new Entities1();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciKayit(Kullanicilar p1)
        {
            db.Kullanicilar.Add(p1);
            db.SaveChanges(); //veri tabanında kaydetme
            return View("","");
          
        }


 
        public ActionResult KayitSil(int id)
        {
            var sil = db.Kullanicilar.Where(x => x.Kul_id == id).FirstOrDefault();
            db.Kullanicilar.Remove(sil);
            db.SaveChanges();
            return View("Index");
        }
       


        public ActionResult KayitGuncelle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult KayitGuncelle(Kullanicilar p1)
        {
            var guncelle = db.Kullanicilar.Find(p1.Kul_Mail);
            //guncelle.Kullanici = p1.Kullanici;
            guncelle.Kul_Ad = p1.Kul_Ad;
            guncelle.Kul_Ad = p1.Kul_Ad;
            guncelle.Kul_Soyad = p1.Kul_Soyad;
            guncelle.Kul_Sifre = p1.Kul_Sifre;
            
            ViewBag.Mesaj = "KAYIT GÜNCELLENMİŞTİR";
            db.SaveChanges();

            return View("Kullanici", "KayitlarList");

        }

        public ActionResult KayitlarList()
        {
            var model = db.Kullanicilar.ToList();
            return View(model);
        }
    }
}