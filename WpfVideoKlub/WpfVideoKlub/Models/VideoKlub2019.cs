namespace WpfVideoKlub.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VideoKlub2019 : DbContext
    {
        public VideoKlub2019()
            : base("name=VideoKlub2019")
        {
        }

        public virtual DbSet<Clan> Clanovi { get; set; }
        public virtual DbSet<Film> Filmovi { get; set; }
        public virtual DbSet<Iznajmljivanje> Iznajmljivanja { get; set; }
        public virtual DbSet<Zanr> Zanrovi { get; set; }
        public virtual DbSet<View_Iznajmljivanja> View_Iznajmljivanja { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>()
                .Property(e => e.LicnaKarta)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .HasMany(e => e.Iznajmljivanja)
                .WithRequired(e => e.Clan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Iznajmljivanja)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Iznajmljivanje>()
                .Property(e => e.CenaPoDanu)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Zanr>()
                .HasMany(e => e.Filmovi)
                .WithRequired(e => e.Zanr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<View_Iznajmljivanja>()
                .Property(e => e.CenaPoDanu)
                .HasPrecision(6, 2);
        }
    }
}
