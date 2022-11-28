using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models;

namespace E_Ticaret.Controllers
{
    public class SepetController : Controller
    {
        Entities1 db = new Entities1();
        
        // GET: Sepet
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Kul_Mail == kullaniciAdi);
                var model = db.Sepet.Where(x => x.Kullanici_id == kullanici.Kul_id &&x.SipVerildimi==0).ToList();
                var kid = db.Sepet.FirstOrDefault(x => x.Kullanici_id == kullanici.Kul_id);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "SEPETİNİZDE ÜRÜN BULUNMAMAKTADIR";
                
                    }
                    else if (kid != null)
                    {
                        Tutar = db.Sepet.Where(x => x.Kullanici_id == kullanici.Kul_id).Sum(x => x.ToplamTutar);
                        ViewBag.Tutar = "SEPET TOPLAM =  " + Tutar + "TL";
                    }
                    ViewBag.USR_ID = ((Kullanicilar)Session["Users"]).Kul_id;
                }
                return View(model);
            }
            return HttpNotFound();
        }
        public void Urunler()
        {

        }
        public ActionResult Sepet()
        {
            var model = db.Kullanicilar.ToList();
           
            return View(model);

        }


        public JsonResult SepetSil(int id)
        {
            try
            {
                var sil = db.Sepet.Where(x => x.Spt_id == id).FirstOrDefault();
                if (sil != null)
                {
                    db.Sepet.Remove(sil);
                    db.SaveChanges();
                }

                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json("FAIL");          
            }

        }

        public ActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = db.Kullanicilar.FirstOrDefault(x => x.Kul_Mail == User.Identity.Name);
                count = db.Sepet.Where(x => x.Kullanici_id == model.Kul_id).Count();
                ViewBag.Count = count;

                if (count == 0)
                {
                    ViewBag.Count = count;
                }
                return PartialView();

            }
            return HttpNotFound();
        }

        public void DinamikMiktar(int id,decimal miktari)
        {
            var model = db.Sepet.Find();
            model.Miktar = miktari;
            model.ToplamTutar = model.spt_fiyat * model.Miktar;
            db.SaveChanges();
        }


        [HttpGet]
        public ActionResult SepetKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SepetKayit(Kullanicilar p1)
        {
            db.Kullanicilar.Add(p1);
            db.SaveChanges();
            ViewBag.Mesaj = "Eklendi";
            return View();


        }
        [HttpPost]
        public ActionResult SepetEkle(Sepet p1)
        {
            p1.Kullanici_id = 7;
            p1.ToplamTutar = p1.Miktar * p1.spt_fiyat;
            db.Sepet.Add(p1);
            db.SaveChanges();
            ViewBag.Mesaj = "Eklendi";
            return Json("");


        }
        public JsonResult SiparisVer(int Kul_ID)
        {

            string msj = "";
            var sepetl = db.Sepet.Where(x => x.SipVerildimi == 0 &&x.Kullanici_id== Kul_ID).ToList();

            try
            {
                for (int i = 0; i < sepetl.Count; i++)
                {
                    var sepet = sepetl[i];
                    Siparisler s = new Siparisler();
                    s.Kul_id = sepet.Kullanici_id;
                    s.SDate = sepet.SDate;
                    s.Sprs_Fiyat = sepet.spt_fiyat;
                    s.Sprs_Miktar = sepet.Miktar;
                    s.Urun_id = sepet.UrunId;
                    db.Siparisler.Add(s);
                    db.SaveChanges();
                }

                msj = "OK";
                db.Database.ExecuteSqlCommand(" Update Sepet set [SipVerildimi]=1 where Kullanici_id= " + Kul_ID);
            }
            catch (Exception ex)
            {
                msj = "FAIL";

            }
            return Json(msj);
        }

        public ActionResult Siparisler()
        {
            var model = db.Siparisler.ToList();
         

            return View(model);

        }
       

    }


}