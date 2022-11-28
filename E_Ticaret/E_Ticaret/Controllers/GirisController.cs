using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models;
using System.Web.Security;


namespace E_Ticaret.Models
{
    public class GirisController : Controller
    {
        Entities1 db = new Entities1();

      
        // GET: Giris
        public ActionResult Giris()
        {

       
            return View();
        }
       

        [HttpPost]
        public ActionResult Giris(Kullanicilar p1)
        {
            var kullaniciVarmi = db.Kullanicilar.FirstOrDefault( x => x.Kul_Mail == p1.Kul_Mail && x.Kul_Sifre == p1.Kul_Sifre);
          if(kullaniciVarmi!=null)
            {
                Session["Users"] = kullaniciVarmi;
                FormsAuthentication.SetAuthCookie(kullaniciVarmi.Kul_Mail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {

               ViewBag.Mesaj = "KULLANICI ADI VEYA ŞİFRE HATALI";
            
               return View("Giris");
            }
            
        }

        public ActionResult UrunEkleme()
        {


            return View();
        }

        [HttpPost]
        public ActionResult UrunEkleme(Urunler p1)
        {
            db.Urunler.Add(p1);
             db.SaveChanges();
            return View("","");
          
        }


        public ActionResult Admin(Admin p1)
        {

            var kullaniciVarmi = db.Admin.FirstOrDefault(x => x.Kul_Mail == p1.Kul_Mail && x.Kul_Sifre == p1.Kul_Sifre);
            if (kullaniciVarmi != null)
            {
                Session["Users"] = kullaniciVarmi;
                FormsAuthentication.SetAuthCookie(kullaniciVarmi.Kul_Mail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.Mesaj = "SADECE YÖNETİCİLER GİRİŞ YAPABİLİR";

                return View("Admin");
            }

        }

    }
}