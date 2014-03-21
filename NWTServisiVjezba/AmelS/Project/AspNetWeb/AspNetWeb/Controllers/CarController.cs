using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AspNetWeb;

namespace AspNetWeb.Controllers
{
    public class CarController : ApiController
    {
        private nwt1Entities db = new nwt1Entities();

        // GET api/Car
        public IQueryable<car> Getcars()
        {
            return db.cars;
        }

        // GET api/Car/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Getcar(int id)
        {
            car car = db.cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT api/Car/5
        public IHttpActionResult Putcar(int id, car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.id)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Car
        [ResponseType(typeof(car))]
        public IHttpActionResult Postcar(car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.id }, car);
        }

        // DELETE api/Car/5
        [ResponseType(typeof(car))]
        public IHttpActionResult Deletecar(int id)
        {
            car car = db.cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool carExists(int id)
        {
            return db.cars.Count(e => e.id == id) > 0;
        }
    }
}