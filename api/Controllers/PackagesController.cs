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
using API.DTO;
using api.Enums;

namespace API.Controllers
{
    public class PackagesController : ApiController
    {
        private ApplicationDbContext dbCtx = new ApplicationDbContext();

        // GET: api/Packages
        public IQueryable<Package> GetPackages()
        {
            return dbCtx.Packages;
        }

        // GET: api/packages/5?shopId=
        [ResponseType(typeof(Package))]
        public IHttpActionResult GetPackage(int id,string shopId)
        {
            Package package = dbCtx.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                //get package poco
            return Ok(package);

            }

        }

        // PUT: api/Packages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPackage(int id, Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }

            dbCtx.Entry(package).State = EntityState.Modified;

            try
            {
                dbCtx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        [ResponseType(typeof(Package))]
        public IHttpActionResult PostPackage(Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbCtx.Packages.Add(package);
            dbCtx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [ResponseType(typeof(Package))]
        public IHttpActionResult DeletePackage(int id)
        {
            Package package = dbCtx.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            dbCtx.Packages.Remove(package);
            dbCtx.SaveChanges();

            return Ok(package);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbCtx.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PackageExists(int id)
        {
            return dbCtx.Packages.Count(e => e.Id == id) > 0;
        }



        //rpc routes
        //GetAllPackagesBrief: rpc/Packages/GetPackagesBriefs?shopId={shopId}&skip={startIndex}&take={set}&status={status}"
        //[Route("rpc/Packages/GetPackagesBriefs?shopId={shopId}&skip={startIndex}&take={set}&status={status}")]
        public IHttpActionResult GetPackagesBriefs(string shopId,int startIndex,int set,int status)
        {
            IQueryable<Package> packages;
            if(status == -1)
            {
                packages = dbCtx.Packages.Where(p => p.ShopId == shopId).Skip(startIndex).Take(set);
            }
            else
            {
                packages = dbCtx.Packages.Where(p => p.ShopId == shopId && p.Status== (OrderStatus)status).Skip(startIndex).Take(set);
            }
            List<PackageBriefDTO> packagesBriefs = new List<PackageBriefDTO>();
            foreach (var package in packages)
            {
                PackageBriefDTO pb = new PackageBriefDTO
                {
                    PackageId = package.Id,
                    PackageStatus = package.Status,
                    DeliveryTime = package.DeliveryTime,
                    ShippingData = package.Order.ShipmentData,
                    TotalCharge = 0
                };
                // now find products that belong to that package
                IEnumerable<OrderProduct> PackageProducts = package.Order.OrderProducts.Where(o => o.Product.ShopID == shopId);
                double totalPrice = 0;
                foreach (var orderProduct in PackageProducts)
                {
                    if (orderProduct.Product.Discount != null)
                    {
                        totalPrice += (orderProduct.Product.Price - (double)orderProduct.Product.Discount) * orderProduct.Quantity;
                    }
                    else
                    {
                        totalPrice += orderProduct.Product.Price * orderProduct.Quantity;
                    }
                }
                pb.TotalCharge = totalPrice;
                packagesBriefs.Add(pb);
            }
            return Ok(packagesBriefs);
        }

    }
}