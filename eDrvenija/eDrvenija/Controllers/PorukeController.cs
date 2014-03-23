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
    public class PorukeController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Poruke/

        public ActionResult Index()
        {
            var poruke = db.poruke.Include(p => p.korisnici).Include(p => p.korisnici1);
            return View(poruke.ToList());
        }

        //
        // GET: /Poruke/Details/5

        public ActionResult Details(int id = 0)
        {
            poruke poruke = db.poruke.Find(id);
            if (poruke == null)
            {
                return HttpNotFound();
            }
            return View(poruke);
        }

        //
        // GET: /Poruke/Create

        public ActionResult Create()
        {
            ViewBag.idKorisnikaPosiljaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika");
            ViewBag.idKorisnikaPrimaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika");
            return View();
        }

        //
        // POST: /Poruke/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(poruke poruke)
        {
            if (ModelState.IsValid)
            {
                db.poruke.Add(poruke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idKorisnikaPosiljaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPosiljaoca);
            ViewBag.idKorisnikaPrimaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPrimaoca);
            return View(poruke);
        }

        //
        // GET: /Poruke/Edit/5

        public ActionResult Edit(int id = 0)
        {
            poruke poruke = db.poruke.Find(id);
            if (poruke == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKorisnikaPosiljaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPosiljaoca);
            ViewBag.idKorisnikaPrimaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPrimaoca);
            return View(poruke);
        }

        //
        // POST: /Poruke/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(poruke poruke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poruke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idKorisnikaPosiljaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPosiljaoca);
            ViewBag.idKorisnikaPrimaoca = new SelectList(db.korisnici, "idKorisnika", "imeKorisnika", poruke.idKorisnikaPrimaoca);
            return View(poruke);
        }

        //
        // GET: /Poruke/Delete/5

        public ActionResult Delete(int id = 0)
        {
            poruke poruke = db.poruke.Find(id);
            if (poruke == null)
            {
                return HttpNotFound();
            }
            return View(poruke);
        }

        //
        // POST: /Poruke/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            poruke poruke = db.poruke.Find(id);
            db.poruke.Remove(poruke);
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