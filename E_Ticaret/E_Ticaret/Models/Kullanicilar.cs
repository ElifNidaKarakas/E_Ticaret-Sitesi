namespace E_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [Key]
        public int Kul_id { get; set; }

        [StringLength(50)]
        public string Kul_Ad { get; set; }

        [StringLength(50)]
        public string Kul_Soyad { get; set; }

        [StringLength(50)]
        public string Kul_Sifre { get; set; }

        [StringLength(50)]
        public string Kul_Mail { get; set; }
    }
}
