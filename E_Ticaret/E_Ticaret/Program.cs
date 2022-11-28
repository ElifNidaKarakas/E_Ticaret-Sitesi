using E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaret
{
     public class Program
    {
        static  void Main(string[] args)
        {
            Kategori k = new Kategori();
            k.Ktgr_id = 1;
            k.Ktgr_Ad = "Telefonlar";

            UrunContext db = new UrunContext();
            db.Kategoriler.Add(k);
            db.SaveChanges();
            Console.WriteLine("veri kayıt edildi");
            Console.ReadLine();

        }

    }
}