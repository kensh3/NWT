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
    public class OglasiApiController : ApiController
    {
        private edrvenijabazaEntities2 db = new edrvenijabazaEntities2();

        #region admin
        // GET api/Oglasi
        public IEnumerable<oglasi> Getoglasis()
        {
            var oglasi = db.oglasi.Include(o => o.kategorije).Include(o => o.korisnici).Include(o => o.tipovioglasa);
            return oglasi.AsEnumerable();
        }

       


        // PUT api/Oglasi/5
        public HttpResponseMessage Putoglasi(int id, oglasi oglasi)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != oglasi.idOglasa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(oglasi).State = EntityState.Modified;

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

        // POST api/Oglasi
        public HttpResponseMessage Postoglasi(oglasi oglasi)
        {
            if (ModelState.IsValid)
            {
                db.oglasi.Add(oglasi);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, oglasi);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = oglasi.idOglasa }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Oglasi/5
        public HttpResponseMessage Deleteoglasi(int id)
        {
            oglasi oglasi = db.oglasi.Find(id);
            if (oglasi == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.oglasi.Remove(oglasi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, oglasi);
        }

        public IEnumerable<oglasi> GetoglasiByType(string naziv)
        {
           
            var lista = from oglasi in db.oglasi
                        from tipovioglasa in db.tipovioglasa //mozda treba join, nasao na netu primjer gdje nije koristen
                        where tipovioglasa.nazivTipaOglasa == naziv
                        select oglasi;
            return lista.AsEnumerable();
        }


        // GET api/Oglasi/zavrseni
        [HttpGet]
       public IEnumerable<oglasi> DajSveZavrseneOglase()
        {

            var lista = from oglasi in db.oglasi
                        where oglasi.zavrsenaTransakcija == true
                        select oglasi;
            if (lista == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lista.AsEnumerable();
        }


       // GET api/Oglasi/kategorija
        [HttpGet]
        public List<Oglas> DajOglasePoKategoriji(int id)
        {

            var stariOglasi = from oglasi in db.oglasi
                        from kategorije in db.kategorije
                        where oglasi.idKategorije == kategorije.idKategorije
                        where oglasi.idKategorije == id
                        select oglasi;

            if (stariOglasi == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            List<Oglas> noviOglasi = new List<Oglas>();
            foreach (oglasi oglasStari in stariOglasi)
            {
                Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
                noviOglasi.Add(noviOglas);
            }

            return noviOglasi;
        }

        // GET api/Oglasi/brojPregleda
        [HttpGet]
        public IEnumerable<oglasi> DajOglasePoBrojuPregleda()
        {

            var lista = from oglasi in db.oglasi orderby oglasi.brojPregledaOglasa descending
                        select oglasi;

            if (lista == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lista.ToList();
        }


        // GET api/Oglasi/brojPreuzimanja
        [HttpGet]
        public IEnumerable<dokumenti> DajOglasePoBrojuPreuzimanja()
        {

            var lista = from dokumenti in db.dokumenti
                        orderby dokumenti.brojPreuzimanja descending
                        select dokumenti;

            if (lista == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lista.AsEnumerable();
        }

        #endregion

        #region user

        [HttpGet]
        public List<Oglas> DajTopCetiriPregledanaOglasa()
        {
            var stariOglasi = (from oglasi in db.oglasi
                               where oglasi.aktivan == true
                              orderby oglasi.brojPregledaOglasa descending
                              select oglasi).Take(4);
            List<Oglas> noviOglasi = new List<Oglas>();
            foreach(oglasi oglasStari in stariOglasi) {
                Oglas noviOglas = new Oglas 
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa =oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan= oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
            noviOglasi.Add(noviOglas);
            }

            return noviOglasi;
        }


        [HttpGet]
        public List<Oglas> DajCetiriNajnovijaOglasa()
        {
            var stariOglasi = (from oglasi in db.oglasi
                               where oglasi.aktivan == true
                               orderby oglasi.datumObjaveOglasa descending
                               select oglasi).Take(4);
            List<Oglas> noviOglasi = new List<Oglas>();
            foreach (oglasi oglasStari in stariOglasi)
            {
                Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
                noviOglasi.Add(noviOglas);
            }

            return noviOglasi;
        }

        [HttpGet]
        public List<Oglas> DajNajnovijeOglase()
        {
            var stariOglasi = (from oglasi in db.oglasi
                               where oglasi.aktivan == true
                               orderby oglasi.datumObjaveOglasa descending
                               select oglasi);
            List<Oglas> noviOglasi = new List<Oglas>();
            foreach (oglasi oglasStari in stariOglasi)
            {
                Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
                noviOglasi.Add(noviOglas);
            }

            return noviOglasi;
        }

        [HttpGet]
        public List<Oglas> DajPreporuceneOglase()
        {
            var stariOglasi = (from oglasi in db.oglasi
                               where oglasi.aktivan == true
                               orderby oglasi.brojPregledaOglasa descending
                               select oglasi);
            List<Oglas> noviOglasi = new List<Oglas>();
            foreach (oglasi oglasStari in stariOglasi)
            {
                Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
                noviOglasi.Add(noviOglas);
            }

            return noviOglasi;
        }

        //OVO JE ONA GLAVNA GET OGLASI METODA; IZ WEBAPI
        // GET api/Oglasi/5
        public Oglas Getoglasi(int id)
        {
            try
            {
                oglasi oglasStari = db.oglasi.Find(id);
                oglasStari.brojPregledaOglasa++;
                db.Entry(oglasStari).State = EntityState.Modified;
                db.SaveChanges();
                if (oglasStari == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }

                Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
                return noviOglas;
            }
            catch(Exception ex){
                return null;
            }
            //return oglasi;
        }

        [HttpGet]
        public Oglas DajOglasPoID(int idOglasa) {
            var oglasStari = db.oglasi.Find(idOglasa);
            oglasStari.brojPregledaOglasa++;
            db.Entry(oglasStari).State = EntityState.Modified;
            db.SaveChanges();
            Oglas noviOglas = new Oglas
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };
            return noviOglas;
        }

        [HttpGet]
        public List<Helpers.Oglas> pretrazioglase(string keyword)
        {
            var oglasiStari = (from ogs in db.oglasi
                                  where ogs.nazivOglasa.Contains(keyword) || ogs.opisOglasa.Contains(keyword)
                                  select ogs).ToList();

            List<Helpers.Oglas> oglasiNovi = new List<Helpers.Oglas>();

            foreach (oglasi oglasStari in oglasiStari)
            {
                Helpers.Oglas oglas = new Helpers.Oglas()
                {
                    idOglasa = oglasStari.idOglasa,
                    nazivOglasa = oglasStari.nazivOglasa,
                    datumObjaveOglasa = oglasStari.datumObjaveOglasa,
                    opisOglasa = oglasStari.opisOglasa,
                    cijena = oglasStari.cijena,
                    brojPregledaOglasa = oglasStari.brojPregledaOglasa,
                    zavrsenaTransakcija = oglasStari.zavrsenaTransakcija,
                    aktivan = oglasStari.aktivan,
                    idTipaOglasa = oglasStari.idTipaOglasa,
                    idKategorije = oglasStari.idKategorije,
                    idKorisnika = oglasStari.idKorisnika
                };

                oglasiNovi.Add(oglas);
            }

            return oglasiNovi;
        }

        [HttpPost]
        public void dodajOglas(Helpers.Oglas oglas)
        {
            oglasi oglasi = new oglasi()
            {
                
               nazivOglasa =oglas.nazivOglasa,
               datumObjaveOglasa = DateTime.Now,         
               opisOglasa=oglas.opisOglasa,
               cijena=oglas.cijena,
               idTipaOglasa=oglas.idTipaOglasa,
               idKategorije=oglas.idKategorije,
               idKorisnika=2,
               brojPregledaOglasa=0,
               zavrsenaTransakcija=false,
               aktivan=true

            };

          

            db.oglasi.Add(oglasi);
            db.SaveChanges();
        }

        [HttpPost]
        public void urediOglas(Helpers.Oglas oglas)
        {
            oglasi oglasi = new oglasi()
            {
                idOglasa = oglas.idOglasa,
                nazivOglasa = oglas.nazivOglasa,
                datumObjaveOglasa = oglas.datumObjaveOglasa,
                opisOglasa = oglas.opisOglasa,
                cijena = oglas.cijena,
                brojPregledaOglasa = oglas.brojPregledaOglasa,
                zavrsenaTransakcija = oglas.zavrsenaTransakcija,
                aktivan = oglas.aktivan,
                idTipaOglasa = oglas.idTipaOglasa,
                idKategorije = oglas.idKategorije,
                idKorisnika = oglas.idKorisnika


            };

            db.Entry(oglasi).State = EntityState.Modified;
            db.SaveChanges();
        }

        [HttpPost]
        public void brisiOglas(Helpers.Oglas oglas)
        {
            var oglasStari = db.oglasi.Find(oglas.idOglasa);
            //brisi komentare vezane za taj oglas
            var starikomentari = (from komentari in db.komentari
                               where komentari.idOglasa==oglasStari.idOglasa
                               select komentari);
            List<Oglas> noviOglasi = new List<Oglas>();
            foreach (komentari komentarStari in starikomentari)
            {
                db.komentari.Remove(komentarStari);
            }




            db.Entry(oglasStari).State = System.Data.EntityState.Deleted;
            db.SaveChanges();
        }

        #endregion





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}