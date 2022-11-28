using E_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticaret
{
    public class UrunContext:DbContext
    {
        public UrunContext():base("E-Ticaret")
        {
                
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urunler> Urunler { get; set; }

    }
}