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
    public class KorisnickeKategorijaController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/KorisnickeKategorija
        public IEnumerable<korisnicikategorije> Getkorisnicikategorijes()
        {
            var korisnicikategorije = db.korisnicikategorije.Include(k => k.kategorije).Include(k => k.korisnici);
            return korisnicikategorije.AsEnumerable();
        }

        // GET api/KorisnickeKategorija/5
        public korisnicikategorije Getkorisnicikategorije(int id)
        {
            korisnicikategorije korisnicikategorije = db.korisnicikategorije.Find(id);
            if (korisnicikategorije == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return korisnicikategorije;
        }

        // PUT api/KorisnickeKategorija/5
        public HttpResponseMessage Putkorisnicikategorije(int id, korisnicikategorije korisnicikategorije)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != korisnicikategorije.idKorisnikaKategorije)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(korisnicikategorije).State = EntityState.Modified;

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

        // POST api/KorisnickeKategorija
        public HttpResponseMessage Postkorisnicikategorije(korisnicikategorije korisnicikategorije)
        {
            if (ModelState.IsValid)
            {
                db.korisnicikategorije.Add(korisnicikategorije);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, korisnicikategorije);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = korisnicikategorije.idKorisnikaKategorije }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/KorisnickeKategorija/5
        public HttpResponseMessage Deletekorisnicikategorije(int id)
        {
            korisnicikategorije korisnicikategorije = db.korisnicikategorije.Find(id);
            if (korisnicikategorije == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.korisnicikategorije.Remove(korisnicikategorije);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, korisnicikategorije);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}