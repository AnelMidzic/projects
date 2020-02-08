using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVideoKlub.Models;
using System.Data.Entity;

namespace WpfVideoKlub.DAL
{
    class IznajmljivanjeDal
    {
        private VideoKlub2019 db;

        public IznajmljivanjeDal(VideoKlub2019 _db)
        {
            db = _db;
        }

        public List<View_Iznajmljivanja> VratiIznajmljivanja()
        {
            using (VideoKlub2019 db = new VideoKlub2019())
            {
                return db.View_Iznajmljivanja.ToList();
            }
        }

        public int UbaciIznajmljivanje(Iznajmljivanje iz)
        {
            try
            {
                db.Iznajmljivanja.Add(iz);
                db.SaveChanges();
                return iz.IznajmljivanjeId;
            }
            catch (Exception)
            {
                db.Entry(iz).State = EntityState.Detached;
                return -1;
            }
            
        }
    }
}
