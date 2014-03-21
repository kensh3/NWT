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
    public class KorisnikController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/Korisnik
        public IEnumerable<korisnici> Getkorisnicis()
        {
            return db.korisnici.AsEnumerable();
        }

        // GET api/Korisnik/5
        public korisnici Getkorisnici(int id)
        {
            korisnici korisnici = db.korisnici.Find(id);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        // GET api/Korisnik/email
        public korisnici GetkorisniciByEmail(string email)
        {
            korisnici korisnici = db.korisnici.Find(email);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        // GET api/Korisnik/username
        public korisnici GetkorisniciByUsername(string user)
        {
            korisnici korisnici = db.korisnici.Find(user);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        // GET api/Korisnik/login
        public korisnici Login([FromBody]string username, [FromBody]string password)
        {
            korisnici korisnici = db.korisnici.Find(username, password);
            if (korisnici == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnici;
        }

        // GET api/Korisnik/logout
        public korisnici Login([FromBody]int id)
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}