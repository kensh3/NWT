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
    public class DokumentiController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // GET: /Dokumenti/

        public ActionResult Index()
        {
            var dokumenti = db.dokumenti.Include(d => d.oglasi);
            return View(dokumenti.ToList());
        }

        //
        // GET: /Dokumenti/Details/5

        public ActionResult Details(int id = 0)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            if (dokumenti == null)
            {
                return HttpNotFound();
            }
            return View(dokumenti);
        }

        //
        // GET: /Dokumenti/Create

        public ActionResult Create()
        {
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa");
            return View();
        }

        //
        // POST: /Dokumenti/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(dokumenti dokumenti)
        {
            if (ModelState.IsValid)
            {
                db.dokumenti.Add(dokumenti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", dokumenti.idOglasa);
            return View(dokumenti);
        }

        //
        // GET: /Dokumenti/Edit/5

        public ActionResult Edit(int id = 0)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            if (dokumenti == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", dokumenti.idOglasa);
            return View(dokumenti);
        }

        //
        // POST: /Dokumenti/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(dokumenti dokumenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokumenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOglasa = new SelectList(db.oglasi, "idOglasa", "nazivOglasa", dokumenti.idOglasa);
            return View(dokumenti);
        }

        //
        // GET: /Dokumenti/Delete/5

        public ActionResult Delete(int id = 0)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            if (dokumenti == null)
            {
                return HttpNotFound();
            }
            return View(dokumenti);
        }

        //
        // POST: /Dokumenti/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            db.dokumenti.Remove(dokumenti);
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