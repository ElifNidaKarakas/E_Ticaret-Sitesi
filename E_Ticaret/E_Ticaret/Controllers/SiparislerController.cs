using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models;

namespace E_Ticaret.Controllers
{
    public class SiparislerController : Controller
    {
        Entities1 db = new Entities1();

        // GET: Siparisler
        public ActionResult Index()
        {
            var model = db.Siparisler.ToList();
           
            return View(model);
        }


        [HttpPost]
   

        public ActionResult Siparisler()
        {

            var model = db.Siparisler.Select(a => new Sepet()
            {
                Kullanici_id = a.Kul_id,
                Spt_id = a.Sprs_id,
                ToplamTutar = a.Sprs_Fiyat,
                Miktar = a.Sprs_Miktar,
                UrunId = a.Urun_id,
                SDate = a.SDate,
            }).ToList();

            return View(model);

        }


        [HttpPost]


    public ActionResult SiparisEkle()
    {
            return View();  
    }


        public ActionResult Siparis(int? Spt_id)
        {
            return View();
          
        }

    }
}