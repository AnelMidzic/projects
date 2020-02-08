using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVideoKlub.Models;
using System.Data.Entity;

namespace WpfVideoKlub.DAL
{
    class ClanDal
    {
        private VideoKlub2019 db;

        public ClanDal(VideoKlub2019 _db)
        {
            db = _db;
        }

        public List<Clan> VratiClanove()
        {
            return db.Clanovi.ToList();
        }

        public int UbaciClana(Clan c)
        {
            try
            {
                db.Clanovi.Add(c);
                db.SaveChanges();
                return c.ClanId;
            }
            catch (Exception)
            {
                db.Entry(c).State = EntityState.Detached;
                return -1;
            }
        }

        public int PromeniClana(Clan c)
        {
            Clan c1 = null;
            try
            {
                c1 = db.Clanovi.Find(c.ClanId);
                c1.Ime = c.Ime;
                c1.Prezime = c.Prezime;
                c1.LicnaKarta = c.LicnaKarta;
                c1.UlicaBroj = c.UlicaBroj;
                c1.Mesto = c.Mesto;

                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(c1).State = EntityState.Unchanged;
                return -1;
            }
        }

        public int ObrisiClana(Clan c)
        {
            Clan c1 = null;
            try
            {
                c1 = db.Clanovi.Find(c.ClanId);
                db.Clanovi.Remove(c1);
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(c1).State = EntityState.Unchanged;
                return -1;
            }
        }
    }
}
