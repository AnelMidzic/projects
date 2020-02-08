using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreAjax.Models
{
    public class ProizvodView
    {
        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        
    }
}
