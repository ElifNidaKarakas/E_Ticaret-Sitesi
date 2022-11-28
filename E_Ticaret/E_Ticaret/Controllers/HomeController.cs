using E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_Ticaret.Controllers
{
    public class HomeController : Controller
    {
        Entities1 db = new Entities1();



        //Model1 context = new Model1();//veri tabanına bağlanabilmek için context üretiyoruz.
        //Models.GirisController dbDeneme = new Models.GirisController();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Urun_Liste()
        {
            using (var ctx = new Entities1())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var UrunList = ctx.Urunler.ToList();
                return Json(UrunList);
            }
        }
      

        public ActionResult UrunAyrinti()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KullaniciKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciKayit(Kullanicilar p1)
        {
            db.Kullanicilar.Add(p1);
            db.SaveChanges();
            ViewBag.Mesaj = "Eklendi";
            return View();
         

        }


        public ActionResult SayfaBilgi()
        {
            return View();
        }

        public ActionResult Telefonlar()
        {
            
            var model = db.Urunler.Where(x => x.Katgr_id == 1).ToList();

            return View(model);
        }
      
        
        public ActionResult Tabletler()
        {
            var model = db.Urunler.Where(x => x.Katgr_id == 3).ToList();

            return View(model);
        }

        public ActionResult Bilgisayarlar()
        {
            var model = db.Urunler.Where(x => x.Katgr_id == 2).ToList();

            return View(model);
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

     

        //[Authorize]
        public ActionResult Sepet()
        {
            var model = db.Kullanicilar.ToList();
            return View(model);
            
        }


    }
}