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
        public IHttpActionResult GetPackageDetails(int id,string shopId)
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
    }
}