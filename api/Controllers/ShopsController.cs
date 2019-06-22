﻿using System;
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

namespace API.Controllers
{
    public class ShopsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
                if(ModelState.Count==1&&ModelState["shop.User"]!=null)
                {
                    return true;
                }
                return false;
            }
            else return true;

        }

       
        
    }
}