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
    public class CartsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private string getUserId()
        {
            string email = RequestContext.Principal.Identity.Name;
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Email == email);
            return user.Id;

        }

        // GET: api/Carts
        [Authorize]
        public IQueryable<Cart> GetCarts()
        {
            IQueryable<Cart> carts = db.Carts.Where(c => c.UserId == getUserId());
            return carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(Cart))]
        [Authorize]
        public IHttpActionResult GetCart(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }
            if(cart.UserId != getUserId())
            {
                return BadRequest();
            }

            return Ok(cart);
        }


        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.ProductId || getUserId() != cart.UserId)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id) || cart.IsDeleted)
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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        [Authorize]
        public IHttpActionResult PostCart(Cart cart)
        {
            cart.UserId = getUserId();
            cart.IsDeleted = false;

            db.Carts.Add(cart);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.ProductId }, cart);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart = db.Carts.Where(c => c.ProductId == id && c.UserId == getUserId()).First();
            if (cart == null)
            {
                return NotFound();
            }

            cart.IsDeleted = true;
            db.Entry(cart).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.ProductId == id) > 0;
        }
    }
}