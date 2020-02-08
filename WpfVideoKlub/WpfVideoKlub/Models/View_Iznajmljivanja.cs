namespace WpfVideoKlub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Iznajmljivanja
    {
        [Key]
        
        public int IznajmljivanjeId { get; set; }

        
        [StringLength(100)]
        public string Naziv { get; set; }

        
        [StringLength(50)]
        public string Ime { get; set; }

        
        [StringLength(50)]
        public string Prezime { get; set; }

        
        [Column(TypeName = "date")]
        public DateTime DatumIznajmljivanja { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatumVracanja { get; set; }

        public decimal? CenaPoDanu { get; set; }
    }
}
