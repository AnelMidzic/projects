using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreAjax.Models;

namespace WebCoreAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly MagacinContext db;

        public HomeController(MagacinContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Kategorije.ToList());
        }

        public JsonResult VratiProizvode(int id=0)
        {
            IEnumerable<ProizvodView> listaProizvoda = db.Proizvodi
                .Select(p => new ProizvodView
                {
                    ProizvodId = p.ProizvodId,
                    KategorijaId = p.KategorijaId,
                    Naziv = p.Naziv,
                    Cena = p.Cena
                });             

            if (id !=0 )
            {
                Kategorija k1 = db.Kategorije.Find(id);

                if (k1 != null)
                {
                    listaProizvoda = listaProizvoda
                        .Where(p => p.KategorijaId == id);
                }
                else
                {
                    return Json(new ProizvodView { });
                }
            }

            return Json(listaProizvoda);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
