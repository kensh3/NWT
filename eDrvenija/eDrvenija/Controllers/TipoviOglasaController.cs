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
    public class TipoviOglasaController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /TipoviOglasa/

        public ActionResult Index()
        {
            return View(db.tipovioglasa.ToList());
        }

        //
        // GET: /TipoviOglasa/Details/5

        public ActionResult Details(int id = 0)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            if (tipovioglasa == null)
            {
                return HttpNotFound();
            }
            return View(tipovioglasa);
        }

        //
        // GET: /TipoviOglasa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoviOglasa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tipovioglasa tipovioglasa)
        {
            if (ModelState.IsValid)
            {
                db.tipovioglasa.Add(tipovioglasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovioglasa);
        }

        //
        // GET: /TipoviOglasa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            if (tipovioglasa == null)
            {
                return HttpNotFound();
            }
            return View(tipovioglasa);
        }

        //
        // POST: /TipoviOglasa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tipovioglasa tipovioglasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovioglasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipovioglasa);
        }

        //
        // GET: /TipoviOglasa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            if (tipovioglasa == null)
            {
                return HttpNotFound();
            }
            return View(tipovioglasa);
        }

        //
        // POST: /TipoviOglasa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            db.tipovioglasa.Remove(tipovioglasa);
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