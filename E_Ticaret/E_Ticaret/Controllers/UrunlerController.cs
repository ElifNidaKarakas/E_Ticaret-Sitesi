using E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;


namespace E_Ticaret.Controllers
{
    public class UrunlerController : Controller
    {
        
        public static Kategori kategori;
        Context c = new Context();
        Entities1 db = new Entities1();

        // GET: Urunler
        public ActionResult Index()
        {
            var model = db.Urunler.ToList(); 
            return View(model);
        }

        [HttpPost]
        public JsonResult Kategoriler()
        {
            List<SelectListItem> degerler = (from i in db.Kategori
                                             select new SelectListItem
                                             {
                                                 Text = i.Ktgr_Ad,
                                                 Value = i.Ktgr_id.ToString()
                                             }).ToList();
            return Json(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategori
                                             select new SelectListItem
                                             {
                                                 Text = i.Ktgr_Ad,
                                                 Value = i.Ktgr_id.ToString()
                                             }).ToList();

            List<SelectListItem> deger1 = (from i in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ktgr_Ad,
                                               Value = i.Ktgr_id.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler urun)
        {
         if (Request.Files.Count > 0)
            {
                string dosyaadi=Path.GetFileName( Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/resimler/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.urun_Resim = "/resimler/" + dosyaadi + uzanti;

            }
            //c.Urunler.Add(urun);
            // c.SaveChanges();

            db.Urunler.Add(urun);
            db.SaveChanges();
            ViewBag.Mesaj = "Eklendi";
            return View("Index");

        }

        public ActionResult UrunSil(int id)
        {
            var sil = db.Urunler.Where(x=>x.Urun_id==id).FirstOrDefault();
            db.Urunler.Remove(sil);
            db.SaveChanges();

            return View("Urunler");
        }

        [HttpGet]
        public ActionResult Urunler()
        {
           
             var model=db.Urunler.ToList();
            return View(model);

        }

        public ActionResult UrunAyrinti(int id)
        {
             var model = db.Urunler.Where(x => x.Urun_id ==id).FirstOrDefault();
             db.Urunler.ToList();
             return View(model);
           
        }

        public ActionResult UrunGuncelle()
        {
            return View();

        }

    }
}