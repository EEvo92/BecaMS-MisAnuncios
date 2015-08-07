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
using Mis_Anuncios.Models;

namespace Mis_Anuncios.Controllers
{
    public class CommercialsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Commercials
        public IQueryable<Commercial> GetCommercials()
        {
            return db.Commercials;
        }

        // GET: api/Commercials/5
        [ResponseType(typeof(Commercial))]
        public IHttpActionResult GetCommercial(int id)
        {
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return NotFound();
            }

            return Ok(commercial);
        }

        // PUT: api/Commercials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommercial(int id, Commercial commercial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commercial.CommercialId)
            {
                return BadRequest();
            }

            db.Entry(commercial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialExists(id))
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

        // POST: api/Commercials
        [ResponseType(typeof(Commercial))]
        public IHttpActionResult PostCommercial(Commercial commercial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commercials.Add(commercial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = commercial.CommercialId }, commercial);
        }

        // DELETE: api/Commercials/5
        [ResponseType(typeof(Commercial))]
        public IHttpActionResult DeleteCommercial(int id)
        {
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return NotFound();
            }

            db.Commercials.Remove(commercial);
            db.SaveChanges();

            return Ok(commercial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommercialExists(int id)
        {
            return db.Commercials.Count(e => e.CommercialId == id) > 0;
        }
    }
}