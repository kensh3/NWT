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
    public class OglasiController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Oglasi/

        public ActionResult Index()
        {
            var oglasi = db.oglasi.Include(o => o.kategorije).Include(o => o.korisnici).Include(o => o.tipovioglasa);
            return View(oglasi.ToList());
        }

        //
        // GET: /Oglasi/Details/5

        public ActionResult Details(int id = 0)
        {
            oglasi oglasi = db.oglasi.Find(id);
            if (oglasi == null)
            {
                return HttpNotFound();
            }
            return View(oglasi);
        }

        //
        // GET: /Oglasi/Create

        public ActionResult Create()
        {
            ViewBag.idKategorije = new SelectList(db.kategorije, "idKategorije", "nazivKategorije");
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika");
            ViewBag.idTipaOglasa = new SelectList(db.tipovioglasa, "idTipaOglasa", "nazivTipaOglasa");
            return View();
        }

        //
        // POST: /Oglasi/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(oglasi oglasi)
        {
            if (ModelState.IsValid)
            {
                db.oglasi.Add(oglasi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idKategorije = new SelectList(db.kategorije, "idKategorije", "nazivKategorije", oglasi.idKategorije);
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", oglasi.idKorisnika);
            ViewBag.idTipaOglasa = new SelectList(db.tipovioglasa, "idTipaOglasa", "nazivTipaOglasa", oglasi.idTipaOglasa);
            return View(oglasi);
        }

        //
        // GET: /Oglasi/Edit/5

        public ActionResult Edit(int id = 0)
        {
            oglasi oglasi = db.oglasi.Find(id);
            if (oglasi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKategorije = new SelectList(db.kategorije, "idKategorije", "nazivKategorije", oglasi.idKategorije);
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", oglasi.idKorisnika);
            ViewBag.idTipaOglasa = new SelectList(db.tipovioglasa, "idTipaOglasa", "nazivTipaOglasa", oglasi.idTipaOglasa);
            return View(oglasi);
        }

        //
        // POST: /Oglasi/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(oglasi oglasi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oglasi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idKategorije = new SelectList(db.kategorije, "idKategorije", "nazivKategorije", oglasi.idKategorije);
            ViewBag.idKorisnika = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", oglasi.idKorisnika);
            ViewBag.idTipaOglasa = new SelectList(db.tipovioglasa, "idTipaOglasa", "nazivTipaOglasa", oglasi.idTipaOglasa);
            return View(oglasi);
        }

        //
        // GET: /Oglasi/Delete/5

        public ActionResult Delete(int id = 0)
        {
            oglasi oglasi = db.oglasi.Find(id);
            if (oglasi == null)
            {
                return HttpNotFound();
            }
            return View(oglasi);
        }

        //
        // POST: /Oglasi/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oglasi oglasi = db.oglasi.Find(id);
            db.oglasi.Remove(oglasi);
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