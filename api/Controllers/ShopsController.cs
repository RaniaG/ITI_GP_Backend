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
using API.DTOs;
using API.Models;

namespace API.Controllers
{
    public class ShopsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Shops
        
        public IQueryable<Shop> GetShops(int PageNumber)
        {

            return db.Shops;
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Shop))]
        
        public IHttpActionResult GetShop(string id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop(string id, Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.Id)
            {
                return BadRequest();
            }

            db.Entry(shop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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

        // POST: api/Shops
        [ResponseType(typeof(Shop))]
        [Authorize]
        public IHttpActionResult PostShop(Shop shop)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            
            string email=RequestContext.Principal.Identity.Name;
            ApplicationUser user=db.Users.FirstOrDefault(u => u.Email == email);
            shop.User = user;
            shop.Id = user.Id;
            shop.Country = db.Countries.FirstOrDefault(c => c.Id == shop.CountryId);
            shop.City = db.Cities.FirstOrDefault(c => c.Id == shop.CityId);
            shop.District = db.Districts.FirstOrDefault(c => c.Id == shop.DistrictId);

            db.Shops.Add(shop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ShopExists(shop.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shop.Id }, new ShopDTO( shop));
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult DeleteShop(string id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }

            db.Shops.Remove(shop);
            db.SaveChanges();

            return Ok(shop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopExists(string id)
        {
            return db.Shops.Count(e => e.Id == id) > 0;
        }
    }
}