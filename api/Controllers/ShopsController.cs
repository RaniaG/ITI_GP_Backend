using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using api.Enums;
using API.DTOs;
using API.Models;
using JsonPatch;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace API.Controllers
{
    public class ShopsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return Request.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().Get<ApplicationUserManager>();
            }
        }
        private async void assignRole(string shopId)
        {

            IdentityRole seller = new IdentityRole("seller");

            /*
               var s = await RoleManager.CreateAsync(seller);
            */
            await UserManager.AddToRoleAsync(shopId, seller.Name);
        }

        // GET: api/Shops/1
        [Route("api/Shops/{PageNumber}")]
        public IQueryable<ShopDTO> GetShops(int PageNumber,int? category=null, double? rating=null, string name="",string sort="rating",string sortdirection="desc")
        {
            IQueryable<Shop> result;
            //categories
            if (category!=null)
            {
                IQueryable<Shop> shops= db.Products.Where(p => p.CategoryId == category).Select(p=>p.Shop);
                result=shops.Where(s => (rating != null && Math.Round(s.Rating) == rating) || s.Name.Contains(name));
            }
            else
            {
                 result=db.Shops.Where(s => (rating != null && Math.Round(s.Rating) == rating) || s.Name.Contains(name));
            }
            //sorting
            
           if(sort=="name")
            {
                if (sortdirection == "desc")
                    result = result.OrderByDescending(el => el.Name);
                else
                    result = result.OrderBy(el => el.Name);
            }
            else{ //rating is default
                if (sortdirection == "asc")
                    result = result.OrderBy(el => el.Rating);
                else
                    result = result.OrderByDescending(el => el.Rating);
            }
            //pagination
            result=result.Skip((PageNumber - 1) * 9).Take(9);
            //dto
            IQueryable<ShopDTO> resDTO = result.Select(shop => new ShopDTO
            {
                Id = shop.Id,
                Name = shop.Name,
                Rating = shop.Rating,
                City = shop.CityId,
                Country = shop.CountryId,
                District = shop.DistrictId,
                About = shop.About,
                Policy = shop.Policy,
                Street = shop.Street,
                User = new ApplicationUserDTO()
                {
                    Id = shop.User.Id,
                    FirstName = shop.User.FirstName,
                    LastName = shop.User.LastName,
                    UserName = shop.User.UserName,
                    Email = shop.User.Email,
                    Photo = shop.User.Photo,
                    Cover = shop.User.CoverPhoto,
                }
            });
            return resDTO;
        }

        // GET: api/Shop/5
        [ResponseType(typeof(Shop))]
        [Route("api/Shop/{id}")]
        public IHttpActionResult GetShop(string id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            if (shop.User == null)
            {
                shop.User = db.Users.Find(shop.Id);
            }
            return Ok(new ShopDTO(shop));
        }

        // PUT: api/Shops
        [ResponseType(typeof(void))]
        [HttpPut]
        [Authorize]
        public IHttpActionResult PutShop(Shop shop)
        {
            string email = RequestContext.Principal.Identity.Name;
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Email == email);
            string id = user.Id;

            if (shop.Id != id)
                return BadRequest();

            //check if shop exists and not deleted
            Shop s=db.Shops.FirstOrDefault(el => el.Id == id);
            if(s == null||s.IsDeleted)
                return NotFound();
            //unchanged values
            shop.IsDeleted = s.IsDeleted;
            shop.Rating = s.Rating;
            shop.User = s.User;
            //s = shop;
            //db.Shops.Attach(shop);
            //db.Entry(shop).State = EntityState.Added;
            //db.Entry(s).State = EntityState.Modified;

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
            if (!ValidateShop(shop))
            {
                return BadRequest(ModelState);
            }
            
            string email=RequestContext.Principal.Identity.Name;
            ApplicationUser user=db.Users.FirstOrDefault(u => u.Email == email);
            shop.User = user;
            shop.Id = user.Id;
            shop.Country = db.Countries.FirstOrDefault(c => c.Id == shop.CountryId);
            shop.City = db.Cities.FirstOrDefault(c => c.Id == shop.CityId);
            shop.District = db.Districts.FirstOrDefault(c => c.Id == shop.DistrictId);
            shop.Rating = 0;
            shop.IsDeleted = false;
            db.Shops.Add(shop);
            assignRole(shop.Id);
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

        // DELETE: api/Shops
        [ResponseType(typeof(Shop))]
        [Authorize]
        public IHttpActionResult DeleteShop()
        {
            string email = RequestContext.Principal.Identity.Name;
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Email == email);
            
            Shop shop = db.Shops.Find(user.Id);
            if (shop == null)
            {
                return NotFound();
            }

            shop.IsDeleted = true;
            db.Entry(shop).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }


        /* change photo and cover */

        
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
        private bool ValidateShop(Shop shop)
        {

            if (!ModelState.IsValid)
            {
                if (ModelState.Count == 1 && ModelState["shop.User"] != null)
                {
                    return true;
                }
                return false;
            }
            else return true;

        }

        //[Route("api/shop/GetSubscriptionType")]
        public IHttpActionResult GetSubscriptionType([FromUri] string id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            var subscription = new { subscriptionType = shop.Subscription == 0 ? "free" : "premium" };
            return Ok(subscription);
        }
        public IHttpActionResult GetShopInventoryInfo([FromUri] string id)
        {
            Shop shop = db.Shops.Find(id);
           
            if (shop == null)
            {
                return NotFound();
            }
            int usedSlots =shop.Products!=null?shop.Products.Count(p=>!p.IsDeleted):0;
            var InventoryInfo = new { maxSlots = shop.Subscription == 0 ? 50 : 100, usedSlots = usedSlots };
            return Ok(InventoryInfo);
        }

    }
}