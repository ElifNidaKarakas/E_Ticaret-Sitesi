namespace E_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sepet")]
    public partial class Sepet
    {
        [Key]
        public int Spt_id { get; set; }

        public int? Kullanici_id { get; set; }

        public decimal? spt_fiyat { get; set; }

        public decimal? Miktar { get; set; }

        public int? UrunId { get; set; }

        public DateTime? SDate { get; set; }
        public int? SipVerildimi { get; set; }
        public decimal? ToplamTutar 
        { 
            get 
            {
                return Miktar * spt_fiyat;
            }
            set
            {
                value = Miktar * spt_fiyat;
            }
        }
    }
}
