using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using eDrvenija.eDrvenija.Models;

namespace eDrvenija.eDrvenija.Controllers
{
    public class KorisniciApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        # region apis for admin
        // GET api/Korisnik
        public IEnumerable<korisnici> Getkorisnicis()
        {
            return db.korisnici.AsEnumerable();
        }

        // GET api/Korisnik/5
        [HttpGet]
        public korisnici Getkorisnici(int id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        [HttpGet]
        public int DajBrojNovihKorisnikaByBrojDana(int brojDana = 7)
        {
            DateTime now = DateTime.Now;
            now = now.AddDays((-1)*brojDana);
            int brojNovihKorisnika = (from kors in db.korisnici
                                      where kors.korisnikAktivanOd >= now
                                      select kors).Count();
            return brojNovihKorisnika;
        }

        [HttpGet]
        public int DajBrojKorisnika()
        {
            int brojKorisnika = db.korisnici.Count();
            return brojKorisnika;
        }




        [HttpGet]
        public int DajBrojAktivnihKorisnika()
        {
            int brojAktivnihKorisnika = (from kors in db.korisnici
                                         where kors.aktivan == true
                                         select kors).Count();
            return brojAktivnihKorisnika;
        }

        [HttpGet]
        public int DajBrojNeaktivnihKorisnika()
        {
            int brojNeaktivnihKorisnika = (from kors in db.korisnici
                                         where kors.aktivan == false
                                         select kors).Count();
            return brojNeaktivnihKorisnika;
        }

        [HttpGet]
        public int DajBrojAktivnihKorisnikaByOcjena(int ocjena)
        {
            int brojAktivnihKorisnika = (from kors in db.korisnici
                                           where kors.aktivan == true && kors.ocjena == ocjena
                                           select kors).Count();
            return brojAktivnihKorisnika;
        }

        [HttpGet]
        public int DajBrojNeaktivnihKorisnikaByOcjena(int ocjena)
        {
            int brojNeaktivnihKorisnika = (from kors in db.korisnici
                                           where kors.aktivan == false && kors.ocjena == ocjena
                                           select kors).Count();
            return brojNeaktivnihKorisnika;
        }
        
  

        // GET api/Korisnik/email
        public korisnici GetkorisniciByEmail(string email)
        {
            korisnici korisnik = db.korisnici.FirstOrDefault(kor => kor.eMailKorisnika == email);

            if (korisnik == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnik;
        }

        // GET api/Korisnik/username
        public korisnici GetkorisniciByUsername(string user)
        {
            korisnici korisnik = db.korisnici.FirstOrDefault(kor => kor.korisnickoImeKorisnika == user);
            if (korisnik == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnik;
        }

        // GET api/Korisnik/login
        [HttpPost]
        public korisnici Login(string username, string password)
        {
            korisnici korisnik = (from korisnici in db.korisnici
                                  where korisnici.korisnickoImeKorisnika == username && korisnici.lozinkaKorisnika == password
                                  select korisnici).First();
            
            var session = HttpContext.Current.Session;
            session["id"]=korisnik.idKorisnika;
            
            if (korisnik == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            
            return korisnik;
        }

        // GET api/Korisnik/loginstatus
        [HttpGet]
        public string loginstatus ()
        {
            var session = HttpContext.Current.Session;
            if (session == null || session["id"] == null)
            {
                session["nesto"] = "blabla";
                return "Niste logovani"+session["nesto"];
            }
            else return "Logovani ste vas id je:" + session["id"];
        }

        // GET api/Korisnik/logout
        [HttpGet]
        public korisnici Logout(int id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        // PUT api/Korisnik/5
        public HttpResponseMessage Putkorisnici(int id, korisnici korisnici)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != korisnici.idKorisnika)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(korisnici).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Korisnik
        public HttpResponseMessage Postkorisnici(korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.korisnici.Add(korisnici);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, korisnici);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = korisnici.idKorisnika }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Korisnik/5
        public HttpResponseMessage Deletekorisnici(int id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.korisnici.Remove(korisnici);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, korisnici);
        }

        public IEnumerable<korisnici> GetTopKorisnike(int broj)
        {
            var lista = (from korisnici in db.korisnici
                         from oglasi in db.oglasi
                         from dokumenti in db.dokumenti
                         where korisnici.idKorisnika == oglasi.idKorisnika
                         where dokumenti.idOglasa == oglasi.idOglasa
                         orderby dokumenti.brojPreuzimanja descending
                         select korisnici).Take(broj);
            return lista.AsEnumerable();
        }

        #endregion

        #region apis for user

        [HttpPut]
        public void putkorisnik(Helpers.Korisnik korisnik)
        {
            var korisnici = new korisnici() {
                idKorisnika = korisnik.Id,
                imeKorisnika = korisnik.Ime,
                prezimeKorisnika = korisnik.Prezime,
                eMailKorisnika = korisnik.EMail,
                brojTelefonaKorisnika = korisnik.BrojTelefona,
                aktivan = true,
                korisnickoImeKorisnika = korisnik.KorisnickoIme,
                lozinkaKorisnika = korisnik.LozinkaKorisnika,
                avatarKorisnika = null,
                korisnikAktivanOd = null,
                ocjena = korisnik.Ocjena,
                idTipaKorisnika = korisnik.IdTipKorisnika
            };
            db.Entry(korisnici).State = EntityState.Modified;
            db.SaveChanges();
        }

        [HttpGet]
        public Helpers.Korisnik dajkorisnika(int id)
        {
            var kor = (from kors in db.korisnici
                       where kors.idKorisnika == id
                       select kors).FirstOrDefault();

            Helpers.Korisnik korisnik = new Helpers.Korisnik()
            {
                Id = kor.idKorisnika,
                Ime = kor.imeKorisnika,
                Prezime = kor.prezimeKorisnika,
                EMail = kor.eMailKorisnika,
                BrojTelefona = kor.brojTelefonaKorisnika,
                Ocjena = (double) (kor.ocjena == null ? 0 : kor.ocjena),
                KorisnickoIme = kor.korisnickoImeKorisnika,
                LozinkaKorisnika = kor.lozinkaKorisnika,
                IdTipKorisnika = kor.idTipaKorisnika
            };

            return korisnik;
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}