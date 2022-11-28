namespace E_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Kategori")]
    public partial class Kategori
    {
        [Key]
        public int Ktgr_id { get; set; }

        [StringLength(50)]
        public string Ktgr_Ad { get; set; }

        [NotMapped]
        public SelectList MobileList { get; set; }
    }
}
