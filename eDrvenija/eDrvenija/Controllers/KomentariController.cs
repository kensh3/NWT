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
    public class KomentariController : ApiController
    {
        private KomentariContext db = new KomentariContext();

        // GET api/Komentari
        public IEnumerable<komentari> Getkomentaris()
        {
            return db.komentaris.AsEnumerable();
        }

        // GET api/Komentari/5
        public komentari Getkomentari(int id)
        {
            komentari komentari = db.komentaris.Find(id);
            if (komentari == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return komentari;
        }

        // PUT api/Komentari/5
        public HttpResponseMessage Putkomentari(int id, komentari komentari)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != komentari.idKomentara)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(komentari).State = EntityState.Modified;

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

        // POST api/Komentari
        public HttpResponseMessage Postkomentari(komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.komentaris.Add(komentari);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, komentari);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = komentari.idKomentara }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Komentari/5
        public HttpResponseMessage Deletekomentari(int id)
        {
            komentari komentari = db.komentaris.Find(id);
            if (komentari == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.komentaris.Remove(komentari);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, komentari);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}