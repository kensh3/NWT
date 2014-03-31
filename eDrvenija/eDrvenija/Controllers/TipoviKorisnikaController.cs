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
    public class TipoviKorisnikaController : BaseController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /TipoviKorisnika/

        public ActionResult Index()
        {
            return View(db.tipovikorisnika.ToList());
        }

        //
        // GET: /TipoviKorisnika/Details/5

        public ActionResult Details(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // GET: /TipoviKorisnika/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoviKorisnika/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tipovikorisnika tipovikorisnika)
        {
            if (ModelState.IsValid)
            {
                db.tipovikorisnika.Add(tipovikorisnika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovikorisnika);
        }

        //
        // GET: /TipoviKorisnika/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // POST: /TipoviKorisnika/Edit/5

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
        // GET: /TipoviKorisnika/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            if (tipovikorisnika == null)
            {
                return HttpNotFound();
            }
            return View(tipovikorisnika);
        }

        //
        // POST: /TipoviKorisnika/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            db.tipovikorisnika.Remove(tipovikorisnika);
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