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
using eDrvenija.eDrvenija.Helpers;

namespace eDrvenija.eDrvenija.Controllers
{
    public class KategorijeApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/KategorijeApi
        public IEnumerable<kategorije> Getkategorijes()
        {
            return db.kategorije.AsEnumerable();
        }

        // GET api/KategorijeApi/5
        public kategorije Getkategorije(int id)
        {
            kategorije kategorije = db.kategorije.Find(id);
            if (kategorije == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return kategorije;
        }

        // PUT api/KategorijeApi/5
        public HttpResponseMessage Putkategorije(int id, kategorije kategorije)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != kategorije.idKategorije)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(kategorije).State = EntityState.Modified;

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

        // POST api/KategorijeApi
        public HttpResponseMessage Postkategorije(kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.kategorije.Add(kategorije);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, kategorije);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = kategorije.idKategorije }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/KategorijeApi/5
        public HttpResponseMessage Deletekategorije(int id)
        {
            kategorije kategorije = db.kategorije.Find(id);
            if (kategorije == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.kategorije.Remove(kategorije);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, kategorije);
        }


        [HttpGet]
        public List<Kategorija> dajKategorije()
        {
            var kategorijeStare = from kategorije in db.kategorije select kategorije;
            List<Kategorija> kategorijaNovi = new List<Kategorija>();
            foreach (kategorije kategorijaStara in kategorijeStare)
            {
                Kategorija kategorijaNova = new Kategorija
                {
                    idKategorije = kategorijaStara.idKategorije,
                    nazivKategorije = kategorijaStara.nazivKategorije
                };
                kategorijaNovi.Add(kategorijaNova);
            }
            return kategorijaNovi;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}