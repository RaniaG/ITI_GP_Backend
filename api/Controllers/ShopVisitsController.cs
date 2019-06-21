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
using API.Models;

namespace API.Controllers
{
    public class ShopVisitsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ShopVisits
        public IQueryable<ShopVisit> GetShopVisits()
        {
            return db.ShopVisits;
        }

        // GET: api/ShopVisits/5
        [ResponseType(typeof(ShopVisit))]
        public IHttpActionResult GetShopVisit(int id)
        {
            ShopVisit shopVisit = db.ShopVisits.Find(id);
            if (shopVisit == null)
            {
                return NotFound();
            }

            return Ok(shopVisit);
        }

        // PUT: api/ShopVisits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShopVisit(int id, ShopVisit shopVisit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shopVisit.Id)
            {
                return BadRequest();
            }

            db.Entry(shopVisit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopVisitExists(id))
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

        // POST: api/ShopVisits
        [ResponseType(typeof(ShopVisit))]
        public IHttpActionResult PostShopVisit(ShopVisit shopVisit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShopVisits.Add(shopVisit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shopVisit.Id }, shopVisit);
        }

        // DELETE: api/ShopVisits/5
        [ResponseType(typeof(ShopVisit))]
        public IHttpActionResult DeleteShopVisit(int id)
        {
            ShopVisit shopVisit = db.ShopVisits.Find(id);
            if (shopVisit == null)
            {
                return NotFound();
            }

            db.ShopVisits.Remove(shopVisit);
            db.SaveChanges();

            return Ok(shopVisit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopVisitExists(int id)
        {
            return db.ShopVisits.Count(e => e.Id == id) > 0;
        }
    }
}