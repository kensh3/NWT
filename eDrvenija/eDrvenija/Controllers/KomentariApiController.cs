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
    public class KomentariApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/KomentariApi
        public IEnumerable<komentari> Getkomentaris()
        {
            var komentari = db.komentari.Include(k => k.korisnici).Include(k => k.oglasi);
            return komentari.AsEnumerable();
        }

        [HttpGet]
        public List<komentari> dajkomentare()
        {
            var komentari = from koments in db.komentari select koments;
            return komentari.ToList();
        }

        [HttpGet]
        public int DajBrojKomentara()
        {
            int brojKomentara = db.komentari.Count();
            return brojKomentara;
        }

        // GET api/KomentariApi/5
        public komentari Getkomentari(int id)
        {
            komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return komentari;
        }

        // PUT api/KomentariApi/5
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

        // POST api/KomentariApi
        public HttpResponseMessage Postkomentari(komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.komentari.Add(komentari);
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

        // DELETE api/KomentariApi/5
        public HttpResponseMessage Deletekomentari(int id)
        {
            komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.komentari.Remove(komentari);

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