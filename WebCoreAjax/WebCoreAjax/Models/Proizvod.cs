using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreAjax.Models
{
    [Table("Proizvod")]
    public partial class Proizvod
    {
        
        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }

        public virtual Kategorija Kategorija { get; set; }
    }
}
