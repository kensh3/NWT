using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDrvenija.eDrvenija.Models;
using eDrvenija.eDrvenija.Helpers;

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

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "TipoviKorisnika");
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