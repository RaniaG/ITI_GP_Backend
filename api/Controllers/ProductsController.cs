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
using API.Helpers;
using API.Models;

namespace API.Controllers
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Products/1
        [Route("api/Products/{PageNumber}")]
        public IQueryable<ProductDTO> GetProducts(int PageNumber,
            int? category = null, double? rating = null,
            double? price = null, string shop = null,
            string name = "", string sort = "rating",
            string sortdirection = "desc")
        {
            IQueryable<Product> result;

            //results
            result = db.Products
                .Where(el => (category != null && el.CategoryId == category)
                || (rating != null && rating == Math.Round(el.Rating))
                || (price != null && price == el.Price)
                || (shop != null && el.ShopID == shop)
                || (el.Name.Contains(name)));
            //sorting
            if (sort == "name")
            {
                if (sortdirection == "desc")
                    result = result.OrderByDescending(el => el.Name);
                else
                    result = result.OrderBy(el => el.Name);
            }
            else if (sort == "shop")
            {
                if (sortdirection == "asc")
                    result = result.OrderBy(el => el.Shop.Name);
                else
                    result = result.OrderByDescending(el => el.Shop.Name);
            }
            else
            { //rating is default
                if (sortdirection == "asc")
                    result = result.OrderBy(el => el.Rating);
                else
                    result = result.OrderByDescending(el => el.Rating);
            }

            //pagination
            result = result.Skip((PageNumber - 1) * 9).Take(9);
            IQueryable<ProductDTO> resDTO = result.Select(el => new ProductDTO()
            {
                Id = el.Id,
                Name = el.Name,
                Price = el.Price,
                Discount = el.Discount,
                Quantity = el.Quantity,
                Terms = el.Terms,
                Variations = el.Variations,
                Rating = el.Rating,
                Images = el.Images,
                Approved = el.Approved,
                Active = el.Active,
                PublishTime = el.PublishTime,
                LifeTime = el.LifeTime,
                CategoryId = el.CategoryId,
                Shop = el.ShopID
            });
            return resDTO;
        }

        // GET: api/FavoriteItems
        //[ResponseType(typeof(Product))]
        //[Route("api/FavoriteItems")]
        //[Authorize]
        //public List<Product> GetFavoriteItems()
        //{
        //    ApplicationUser user = Helper.GetUser(RequestContext, db);
        //    //return user.FavouriteProducts.ToList();
        //}

        // GET: api/Products/5
        [ResponseType(typeof(ProductDTO))]
        [Route("api/Product/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null || product.IsDeleted||product.Shop.IsDeleted)
            {
                return NotFound();
            }

            return Ok(ProductDTO.ToDTO(product));
        }

        
        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        [Authorize]
        //public IHttpActionResult PutProduct([FromUri]int id, [FromBody]Product product)
        public IHttpActionResult PutProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //get product from db
            //if (id != product.Id)
            //{
            //    return BadRequest();
            //}
            //Product productDB = db.Products.Find(id);
            Product productDB = db.Products.Find(product.Id);

            if (productDB == null)
                return NotFound();
            ApplicationUser user = Helper.GetUser(RequestContext, db);

            if (product.ShopID !=null&&product.ShopID != user.Id) //user is trying to edit a product in another shop
                return Unauthorized();

            product.Rating = productDB.Rating;
            product.Approved = productDB.Approved;
            product.LifeTime = productDB.LifeTime;
            product.Shop = productDB.Shop;
            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
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

        // POST: api/Products
        [ResponseType(typeof(ProductDTO))]
        [Authorize]
        public IHttpActionResult PostProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = Helper.GetUser(RequestContext,db);
            if (db.Shops.Find(user.Id) == null) //user is trying to add product without creating shop
                return Unauthorized();
            Product product = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Discount = productDTO.Discount,
                Quantity = productDTO.Quantity,
                Terms = productDTO.Terms,
                Variations = productDTO.Variations,
                Images = productDTO.Images,
                CategoryId = productDTO.CategoryId,
                Category = db.Categories.Find(productDTO.CategoryId),
                Shop = db.Shops.Find(user.Id),
                PublishTime=DateTime.Now,
                //LifeTime=
            };
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id },  ProductDTO.ToDTO(product) );
        }

        // DELETE: api/Products/5
        [Authorize]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.IsDeleted = true;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("api/Products/Favourite/{id}")]
        public IHttpActionResult FavouriteProduct(int id)
        {
            Product product = db.Products.Find(id);
            ApplicationUser user = Helper.GetUser(RequestContext, db);
            if (product == null)
            {
                return NotFound();
            }
            product.FavouritedByUsers.Add(user);
            db.SaveChanges();

            return Ok();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
        
    }
}