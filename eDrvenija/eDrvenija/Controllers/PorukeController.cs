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
    public class PorukeController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/Poruke
        public IEnumerable<poruke> Getporukes()
        {
            return db.poruke.AsEnumerable();
        }

        // GET api/Poruke/5
        public poruke Getporuke(int id)
        {
            poruke poruke = db.poruke.Find(id);
            if (poruke == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return poruke;
        }

        // PUT api/Poruke/5
        public HttpResponseMessage Putporuke(int id, poruke poruke)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != poruke.idPoruke)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(poruke).State = EntityState.Modified;

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

        // POST api/Poruke
        public HttpResponseMessage Postporuke(poruke poruke)
        {
            if (ModelState.IsValid)
            {
                db.poruke.Add(poruke);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, poruke);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = poruke.idPoruke }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Poruke/5
        public HttpResponseMessage Deleteporuke(int id)
        {
            poruke poruke = db.poruke.Find(id);
            if (poruke == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.poruke.Remove(poruke);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, poruke);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}