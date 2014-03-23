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
    public class KomentariController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Komentari/

        public ActionResult Index()
        {
            var komentari = db.komentari.Include(k => k.korisnici).Include(k => k.oglasi);
            return View(komentari.ToList());
        }

        //
        // GET: /Komentari/Details/5

        public ActionResult Details(int id = 0)
        {
            komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            return View(komentari);
        }

        //
        // GET: /Komentari/Create

        public ActionResult Create()
        {
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika");
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa");
            return View();
        }

        //
        // POST: /Komentari/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.komentari.Add(komentari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", komentari.idKorisnika);
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", komentari.idOglasa);
            return View(komentari);
        }

        //
        // GET: /Komentari/Edit/5

        public ActionResult Edit(int id = 0)
        {
            komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", komentari.idKorisnika);
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", komentari.idOglasa);
            return View(komentari);
        }

        //
        // POST: /Komentari/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", komentari.idKorisnika);
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", komentari.idOglasa);
            return View(komentari);
        }

        //
        // GET: /Komentari/Delete/5

        public ActionResult Delete(int id = 0)
        {
            komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            return View(komentari);
        }

        //
        // POST: /Komentari/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            komentari komentari = db.komentari.Find(id);
            db.komentari.Remove(komentari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}