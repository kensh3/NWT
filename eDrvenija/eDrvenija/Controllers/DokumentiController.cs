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
    public class DokumentiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/Dokumenti
        public IEnumerable<dokumenti> Getdokumentis()
        {
            var dokumenti = db.dokumenti.Include(d => d.oglasi);
            return dokumenti.AsEnumerable();
        }

        // GET api/Dokumenti/5
        public dokumenti Getdokumenti(int id)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            if (dokumenti == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dokumenti;
        }

        // PUT api/Dokumenti/5
        public HttpResponseMessage Putdokumenti(int id, dokumenti dokumenti)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != dokumenti.idDokumenta)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(dokumenti).State = EntityState.Modified;

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

        // POST api/Dokumenti
        public HttpResponseMessage Postdokumenti(dokumenti dokumenti)
        {
            if (ModelState.IsValid)
            {
                db.dokumenti.Add(dokumenti);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, dokumenti);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dokumenti.idDokumenta }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Dokumenti/5
        public HttpResponseMessage Deletedokumenti(int id)
        {
            dokumenti dokumenti = db.dokumenti.Find(id);
            if (dokumenti == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.dokumenti.Remove(dokumenti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dokumenti);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}