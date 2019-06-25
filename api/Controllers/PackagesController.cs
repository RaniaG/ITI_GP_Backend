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

        // GET: rpc/packages/GetPackageDetails/5?shopId=
        [ResponseType(typeof(PackageDetailsDTO))]
        public IHttpActionResult GetPackageDetails(int id,string shopId)
        {
            Package package = dbCtx.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                //get packageDTO
                PackageDetailsDTO pd = new PackageDetailsDTO()
                {
                    DeliveryMethod = "Door To Door",
                    DeliveryTime = package.DeliveryTime,
                    PackageId = package.Id,
                    PackageStatus = package.Status,
                    PaymentMethod = dbCtx.Orders.FirstOrDefault(o => o.Id == package.OrderId).PaymentMethod,
                    ShippingFees=50,
                    TotalCharge=package.Price,                   
                };


                List <OrderProduct> orderProducts  = dbCtx.OrderProducts.Include("Product").Where(op => op.OrderId == package.OrderId ).ToList();
                List<OrderProduct> packageOrder = orderProducts.Where(p => p.Product.ShopID == shopId).ToList();

                Order orderRequested = dbCtx.Orders.FirstOrDefault(o=>o.Id==package.OrderId);
                ShipmentData packageShipmentData = dbCtx.ShipmentDatas.Include("Country").Include("District").Include("City").FirstOrDefault(s => s.Id == orderRequested.ShipmentDataId);
                pd.ShippingData = orderRequested.ShipmentData;

                List<PackageProductDTO> packageProductList = new List<PackageProductDTO>();
                PackageProductDTO singleProduct;
                foreach (var orderProduct in orderProducts)
                {
                    singleProduct = new PackageProductDTO()
                    {
                        Id=orderProduct.Product.Id,
                        Name=orderProduct.Product.Name,
                        Images=orderProduct.Product.Images,
                        PackageId=package.Id,
                        Variations=orderProduct.Variations,
                        Discount= orderProduct.Product.Discount==null?0: orderProduct.Product.Discount,
                        Quantity= orderProduct.Quantity,
                        Price= orderProduct.Quantity,
                    };
                    packageProductList.Add(singleProduct);
                }
                pd.ProductList = packageProductList;
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
        //GetAllPackagesBrief: rpc/Packages/GetPackagesBriefs?shopId={shopId}&skip={skip}&take={take}&status={status}"

            // need a resolver in front to make sure shop exists
        public HttpResponseMessage GetPackagesBriefs(string shopId,int skip,int take,int status)
        {
            IQueryable<Package> packages;
            List<ShipmentData> shipmentDatas = dbCtx.ShipmentDatas.ToList();
            if(status == -1)
            {
                packages = dbCtx.Packages.Where(p => p.ShopId == shopId).Include("Order").OrderBy(p=>p.DeliveryTime).Skip(skip).Take(take);
            }
            else
            {
                packages = dbCtx.Packages.Where(p => p.ShopId == shopId && p.Status== (OrderStatus)status).Skip(skip).Take(take);
            }
            List<PackageBriefDTO> packagesBriefs = new List<PackageBriefDTO>();
            foreach (var package in packages)
            {
                //x.FirstOrDefault(s => s.Id == package.Order.ShipmentDataId);
                PackageBriefDTO pb = new PackageBriefDTO()
                {
                    PackageId = package.Id,
                    PackageStatus = (OrderStatus)package.Status,
                    DeliveryTime = package.DeliveryTime,
                    ShippingData = shipmentDatas.FirstOrDefault(s=>s.UserId == package.Order.UserId && s.Id==package.Order.ShipmentDataId),
                    TotalCharge = package.Price
                };
                // now find products that belong to that package
                //IEnumerable<OrderProduct> PackageProducts = package.Order.OrderProducts.Where(o => o.Product.ShopID == shopId);
                //double totalPrice = 0;
                //foreach (var orderProduct in PackageProducts)
                //{
                //    if (orderProduct.Product.Discount != null)
                //    {
                //        totalPrice += (orderProduct.Product.Price - (double)orderProduct.Product.Discount) * orderProduct.Quantity;
                //    }
                //    else
                //    {
                //        totalPrice += orderProduct.Product.Price * orderProduct.Quantity;
                //    }
                //}
                //pb.TotalCharge = totalPrice;
                packagesBriefs.Add(pb);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, packagesBriefs);

            return response;
        }

    }
}