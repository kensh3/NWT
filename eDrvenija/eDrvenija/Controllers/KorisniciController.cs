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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;


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
        // R E G I S T R A C I J A
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

        if (ModelState.IsValid) // Ovdje pada zbog validacije
             {
                 ModelState.AddModelError("", "Prosao valid.");
                korisnici.aktivan = false;
                db.korisnici.Add(korisnici);
                db.SaveChanges(); // Ovdje pada zbog validacije
                ModelState.Clear();
                EmailManager.SendConfirmationEmail(korisnici);
                korisnici = null;
                return RedirectToAction("Confirmation", "Korisnici");
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

        //
        // GET: /Korisnici/Verify
        public ActionResult Verify(string id)
        {
            if (string.IsNullOrEmpty(id) || (!Regex.IsMatch(id, @"[0-9]")))
            {
                ViewBag.Msg = "Korisnički račun nije validan! Molimo pokušajte ponovo klikom na link koji se nalazi u Vašem mailu za potvrdu registracije.";
                return View("Login");
            }

            else
            {
                int id1 = Int32.Parse(id);
                korisnici korisnik = db.korisnici.Find(id1);
                if (korisnik.aktivan == false)
                {
                    korisnik.aktivan = true;
                    db.Entry(korisnik).State = EntityState.Modified;
                    db.SaveChanges();

                    Session["KorisnikId"] = korisnik.idKorisnika.ToString();
                    return RedirectToAction("Welcome");
                    //return RedirectToAction("Index", "Korisnici");
                }
                else
                {
                    ViewBag.Msg = "Korisnički racun je vec aktiviran";
                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        public class EmailManager
        {
            private const string EmailFrom = "noreply@gmail.com";
            public static void SendConfirmationEmail(korisnici k)
            {
                //var user = Membership.GetUser(userName.ToString());
                var confirmationGuid = k.idKorisnika.ToString();
                var verifyUrl = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Korisnici/Verify/?ID=" + confirmationGuid;

                string subject = "Molimo potvrdite svoju prijavu";
                string body = "Dragi " + k.imeKorisnika + ",\nKako bi potvrdili svoju prijavu potrebno je kliknuti na link u nastavku: "
                   + verifyUrl + "\nLijep pozdrav, \n\n Molimo da na ovaj mail ne odgovarate. Link za potvrdu je privatan.";

                MailAddress posiljalac = new MailAddress("nwt.application@gmail.com", "eDrvenija");
                MailAddress primalac = new MailAddress(k.eMailKorisnika);
                MailMessage message = new MailMessage(posiljalac, primalac);

                message.Subject = subject;
                message.Body = body;

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("nwt.application@gmail.com", "Hana1409"),
                    EnableSsl = true
                };

                client.Send(message);
                //client.Send("nwt.application@gmail.com", k.eMailKorisnika, subject, body);

            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}