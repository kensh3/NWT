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
    public class TipoviKorisnikaApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/TipoviKorisnikaApi
        public IEnumerable<tipovikorisnika> Gettipovikorisnikas()
        {
            return db.tipovikorisnika.AsEnumerable();
        }

        // GET api/TipoviKorisnikaApi/5
        public tipovikorisnika Gettipovikorisnika(int id)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            if (tipovikorisnika == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tipovikorisnika;
        }

        // PUT api/TipoviKorisnikaApi/5
        public HttpResponseMessage Puttipovikorisnika(int id, tipovikorisnika tipovikorisnika)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tipovikorisnika.idTipaKorisnika)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tipovikorisnika).State = EntityState.Modified;

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

        // POST api/TipoviKorisnikaApi
        public HttpResponseMessage Posttipovikorisnika(tipovikorisnika tipovikorisnika)
        {
            if (ModelState.IsValid)
            {
                db.tipovikorisnika.Add(tipovikorisnika);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tipovikorisnika);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tipovikorisnika.idTipaKorisnika }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/TipoviKorisnikaApi/5
        public HttpResponseMessage Deletetipovikorisnika(int id)
        {
            tipovikorisnika tipovikorisnika = db.tipovikorisnika.Find(id);
            if (tipovikorisnika == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tipovikorisnika.Remove(tipovikorisnika);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tipovikorisnika);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}