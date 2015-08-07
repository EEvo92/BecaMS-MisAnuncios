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
    public class AdvertisersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Advertisers
        public IQueryable<Advertiser> GetAdvertisers()
        {
            return db.Advertisers;
        }

        // GET: api/Advertisers/5
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult GetAdvertiser(int id)
        {
            Advertiser advertiser = db.Advertisers.Find(id);
            if (advertiser == null)
            {
                return NotFound();
            }

            return Ok(advertiser);
        }

        // PUT: api/Advertisers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdvertiser(int id, Advertiser advertiser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advertiser.AdvertiserId)
            {
                return BadRequest();
            }

            db.Entry(advertiser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertiserExists(id))
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

        // POST: api/Advertisers
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult PostAdvertiser(Advertiser advertiser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Advertisers.Add(advertiser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = advertiser.AdvertiserId }, advertiser);
        }

        // DELETE: api/Advertisers/5
        [ResponseType(typeof(Advertiser))]
        public IHttpActionResult DeleteAdvertiser(int id)
        {
            Advertiser advertiser = db.Advertisers.Find(id);
            if (advertiser == null)
            {
                return NotFound();
            }

            db.Advertisers.Remove(advertiser);
            db.SaveChanges();

            return Ok(advertiser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdvertiserExists(int id)
        {
            return db.Advertisers.Count(e => e.AdvertiserId == id) > 0;
        }
    }
}