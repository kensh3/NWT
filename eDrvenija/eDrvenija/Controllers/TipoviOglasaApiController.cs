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
    public class TipoviOglasaApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        // GET api/TipoviOglasaApi
        public IEnumerable<tipovioglasa> Gettipovioglasas()
        {
            return db.tipovioglasa.AsEnumerable();
        }

        // GET api/TipoviOglasaApi/5
        public tipovioglasa Gettipovioglasa(int id)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            if (tipovioglasa == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tipovioglasa;
        }

        // PUT api/TipoviOglasaApi/5
        public HttpResponseMessage Puttipovioglasa(int id, tipovioglasa tipovioglasa)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tipovioglasa.idTipaOglasa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tipovioglasa).State = EntityState.Modified;

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

        // POST api/TipoviOglasaApi
        public HttpResponseMessage Posttipovioglasa(tipovioglasa tipovioglasa)
        {
            if (ModelState.IsValid)
            {
                db.tipovioglasa.Add(tipovioglasa);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tipovioglasa);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tipovioglasa.idTipaOglasa }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/TipoviOglasaApi/5
        public HttpResponseMessage Deletetipovioglasa(int id)
        {
            tipovioglasa tipovioglasa = db.tipovioglasa.Find(id);
            if (tipovioglasa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tipovioglasa.Remove(tipovioglasa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tipovioglasa);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}