using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVideoKlub.Models;
using System.Data.Entity;

namespace WpfVideoKlub.DAL
{
    class FilmDal
    {
        private VideoKlub2019 db;

        public FilmDal(VideoKlub2019 _db)
        {
            db = _db;
        }

        public List<Film> VratiFilmove()
        {
            return db.Filmovi.Include(f1 => f1.Zanr)
                .ToList();
        }

        public int UbaciFilm(Film f)
        {
            try
            {
                db.Filmovi.Add(f);
                db.SaveChanges();
                return f.FilmId;
            }
            catch (Exception)
            {
                db.Entry(f).State = EntityState.Detached;
                return -1;
            }
        }

        public int PromijeniFilm(Film f)
        {
            Film f1 = null;

            try
            {
                f1 = db.Filmovi.Find(f.FilmId);
                f1.Naziv = f.Naziv;
                f1.ZanrId = f.ZanrId;
                f1.Reziser = f.Reziser;
                f1.Godina = f.Godina;

                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(f1).State = EntityState.Unchanged;
                return -1;
            }
        }

        public int ObrisiFilm(Film f)
        {
            Film f1 = null;

            try
            {
                f1 = db.Filmovi.Find(f.FilmId);
                db.Filmovi.Remove(f1);
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                db.Entry(f1).State = EntityState.Unchanged;
                return -1;
            }
        }
    }
}
