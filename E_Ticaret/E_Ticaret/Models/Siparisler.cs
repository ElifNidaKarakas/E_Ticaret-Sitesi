namespace E_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Siparisler")]
    public partial class Siparisler
    {
        [Key]
        public int Sprs_id { get; set; }

        public decimal? Sprs_Miktar { get; set; }

        public decimal? Sprs_Fiyat { get; set; }

        public int? Kul_id { get; set; }

        public int? Urun_id { get; set; }

        public DateTime? SDate { get; set; }
        //Veri tabanýna yapýlan iþlere dahil edilmez
        [NotMapped]
        public decimal? SipToplam
        {
            get
            {
                return Sprs_Miktar * Sprs_Fiyat;
            }
            set
            {
                value = Sprs_Miktar * Sprs_Fiyat;
            }
        }
    }
}
