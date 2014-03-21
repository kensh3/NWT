using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDrvenija.eDrvenija.Models;

namespace eDrvenija.eDrvenija.Controllers
{
    public class KorisniciController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Korisnici/

        public ActionResult Index()
        {
            var korisnici = db.korisnici.Include(k => k.tipovikorisnika);
            return View(korisnici.ToList());
        }

        //
        // GET: /Korisnici/Details/5

        public ActionResult Details(int id = 0)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View(korisnici);
        }

        //
        // GET: /Korisnici/Create

        public ActionResult Create()
        {
            ViewBag.idTipaKorisnika = new SelectList(db.tipovikorisnika, "idTipaKorisnika", "nazivTipaKorisnika");
            return View();
        }

        //
        // POST: /Korisnici/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.korisnici.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipaKorisnika = new SelectList(db.tipovikorisnika, "idTipaKorisnika", "nazivTipaKorisnika", korisnici.idTipaKorisnika);
            return View(korisnici);
        }

        //
        // GET: /Korisnici/Edit/5

        public ActionResult Edit(int id = 0)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipaKorisnika = new SelectList(db.tipovikorisnika, "idTipaKorisnika", "nazivTipaKorisnika", korisnici.idTipaKorisnika);
            return View(korisnici);
        }

        //
        // POST: /Korisnici/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipaKorisnika = new SelectList(db.tipovikorisnika, "idTipaKorisnika", "nazivTipaKorisnika", korisnici.idTipaKorisnika);
            return View(korisnici);
        }

        //
        // GET: /Korisnici/Delete/5

        public ActionResult Delete(int id = 0)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return HttpNotFound();
            }
            return View(korisnici);
        }

        //
        // POST: /Korisnici/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            db.korisnici.Remove(korisnici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IEnumerable<korisnici> GetNajKorisnici(int broj)
        {
          //placeholder
            
            return null;
        }

        public IEnumerable<korisnici> GetNajaktivnijiKorisnici(int broj)
        {
            var lista = (from korisnici in db.korisnici
                         orderby korisnici.oglasi.Count() descending
                         select korisnici).Take(broj);
            return lista.AsEnumerable();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}