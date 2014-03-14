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
    public class TipKorisnikaController : Controller
    {
        private eDrvenijaContext db = new eDrvenijaContext();

        //
        // GET: /TipKorisnika/

        public ActionResult Index()
        {
            return View(db.tipovikorisnikas.ToList());
        }

        //
        // GET: /TipKorisnika/Details/5

        public ActionResult Details(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnikas.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // GET: /TipKorisnika/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipKorisnika/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tipovikorisnika tipovikorisnika)
        {
            if (ModelState.IsValid)
            {
                db.tipovikorisnikas.Add(tipovikorisnika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovikorisnika);
        }

        //
        // GET: /TipKorisnika/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnikas.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // POST: /TipKorisnika/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tipovikorisnika tipovikorisnika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovikorisnika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipovikorisnika);
        }

        //
        // GET: /TipKorisnika/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnikas.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // POST: /TipKorisnika/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnikas.Find(id);
            db.tipovikorisnikas.Remove(tipovikorisnika);
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