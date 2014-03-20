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
    public class KategorijeController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Kategorije/

        public ActionResult Index()
        {
            return View(db.kategorije.ToList());
        }

        //
        // GET: /Kategorije/Details/5

        public ActionResult Details(int id = 0)
        {
            kategorije kategorije = db.kategorije.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        //
        // GET: /Kategorije/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kategorije/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.kategorije.Add(kategorije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorije);
        }

        //
        // GET: /Kategorije/Edit/5

        public ActionResult Edit(int id = 0)
        {
            kategorije kategorije = db.kategorije.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        //
        // POST: /Kategorije/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorije);
        }

        //
        // GET: /Kategorije/Delete/5

        public ActionResult Delete(int id = 0)
        {
            kategorije kategorije = db.kategorije.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        //
        // POST: /Kategorije/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategorije kategorije = db.kategorije.Find(id);
            db.kategorije.Remove(kategorije);
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