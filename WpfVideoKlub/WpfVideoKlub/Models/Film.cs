namespace WpfVideoKlub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Iznajmljivanja = new HashSet<Iznajmljivanje>();
        }

        public int FilmId { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }

        public int ZanrId { get; set; }

        [StringLength(100)]
        public string Reziser { get; set; }

        public int Godina { get; set; }

        public override string ToString() => Naziv;

        public virtual Zanr Zanr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iznajmljivanje> Iznajmljivanja { get; set; }
    }
}
