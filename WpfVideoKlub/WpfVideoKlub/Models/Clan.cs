namespace WpfVideoKlub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clan")]
    public partial class Clan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clan()
        {
            Iznajmljivanja = new HashSet<Iznajmljivanje>();
        }

        public int ClanId { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(9)]
        public string LicnaKarta { get; set; }

        [Required]
        [StringLength(30)]
        public string UlicaBroj { get; set; }

        [Required]
        [StringLength(50)]
        public string Mesto { get; set; }

        public override string ToString() => Ime + " " + Prezime;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iznajmljivanje> Iznajmljivanja { get; set; }
    }
}
