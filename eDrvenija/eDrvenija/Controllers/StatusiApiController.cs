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
    public class StatusiApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/Statusi
        public IEnumerable<statusi> Getstatusis()
        {
            var statusi = db.statusi.Include(s => s.korisnici);
            return statusi.AsEnumerable();
        }

        // GET api/Statusi/5
        public statusi Getstatusi(int id)
        {
            statusi statusi = db.statusi.Find(id);
            if (statusi == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return statusi;
        }

        // PUT api/Statusi/5
        public HttpResponseMessage Putstatusi(int id, statusi statusi)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != statusi.idStatusa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(statusi).State = EntityState.Modified;

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

        // POST api/Statusi
        public HttpResponseMessage Poststatusi(statusi statusi)
        {
            if (ModelState.IsValid)
            {
                db.statusi.Add(statusi);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, statusi);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = statusi.idStatusa }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Statusi/5
        public HttpResponseMessage Deletestatusi(int id)
        {
            statusi statusi = db.statusi.Find(id);
            if (statusi == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.statusi.Remove(statusi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, statusi);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}