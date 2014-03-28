using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using eDrvenija.eDrvenija.Models;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;


namespace eDrvenija.eDrvenija.Controllers
{
    public class KorisniciController : Controller
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        //
        // Login

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(korisnici korisnik)
        {

            if (ModelState.IsValidField("Korisničko ime") && ModelState.IsValidField("Lozinka"))
            {
                
                var v = db.korisnici.Where(a => a.korisnickoImeKorisnika.Equals(korisnik.korisnickoImeKorisnika) && a.lozinkaKorisnika.Equals(korisnik.lozinkaKorisnika)).FirstOrDefault();
                if (v != null)
                {
                    Session["KorisnikId"] = v.idKorisnika.ToString();
                    return RedirectToAction("Index", "Korisnici");
                }
            }
            return View(korisnik);
        }

        //
        // GET: /Korisnici/

        public ActionResult Index()
        {
            if (Session["KorisnikId"] != null)
            {
                var korisnici = db.korisnici.Include(k => k.tipovikorisnika);
                return View(korisnici.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
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
        public async Task<ActionResult> Create(korisnici korisnici)
        {
            //Captcha provjera

            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(korisnici);
            }

            RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
                return View(korisnici);
            }


            if (ModelState.IsValid)
            {
                db.korisnici.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("Login");
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


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}