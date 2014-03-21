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
    public class TransakcijeController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/Transakcije
        public IEnumerable<transakcije> Gettransakcijes()
        {
            var transakcije = db.transakcije.Include(t => t.korisnici).Include(t => t.oglasi);
            return transakcije.AsEnumerable();
        }

        // GET api/Transakcije/5
        public transakcije Gettransakcije(int id)
        {
            transakcije transakcije = db.transakcije.Find(id);
            if (transakcije == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return transakcije;
        }

        // PUT api/Transakcije/5
        public HttpResponseMessage Puttransakcije(int id, transakcije transakcije)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != transakcije.idTransakcije)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(transakcije).State = EntityState.Modified;

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

        // POST api/Transakcije
        public HttpResponseMessage Posttransakcije(transakcije transakcije)
        {
            if (ModelState.IsValid)
            {
                db.transakcije.Add(transakcije);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, transakcije);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = transakcije.idTransakcije }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Transakcije/5
        public HttpResponseMessage Deletetransakcije(int id)
        {
            transakcije transakcije = db.transakcije.Find(id);
            if (transakcije == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.transakcije.Remove(transakcije);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, transakcije);
        }

        public IEnumerable<transakcije> GetKorisniciTransakcije(int idkorisnika)
        {

            var lista = from transakcije in db.transakcije
                        where transakcije.idKorisnika==idkorisnika
                        select transakcije;
            return lista.AsEnumerable();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}