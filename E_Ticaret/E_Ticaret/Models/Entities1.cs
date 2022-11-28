using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace E_Ticaret.Models
{
    public partial class Entities1 : DbContext
    {
        public Entities1(): base("name=Entities1")
        {
        }

        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Siparisler> Siparisler { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>()
                .Property(e => e.Ktgr_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.Kul_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.Kul_Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.Kul_Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.Kul_Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.Urun_Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.urun_Resim)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
            .Property(e => e.Kul_Ad)
            .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Kul_Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Kul_Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Kul_Mail)
                .IsUnicode(false);

        }
    }
}
