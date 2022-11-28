namespace E_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urunler")]
    public partial class Urunler
    {
        [Key]
        public int Urun_id { get; set; }

        [StringLength(50)]
        public string Urun_Ad { get; set; }

        public decimal? Urun_Fiyat { get; set; }

        public string Urun_Kod { get; set; }

        [Column(TypeName = "text")]
        public string urun_Resim { get; set; }

        public int? Katgr_id { get; set; }
    }
}
