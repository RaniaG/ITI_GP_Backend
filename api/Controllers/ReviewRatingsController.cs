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
    public class ReviewRatingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReviewRatings
        public IQueryable<ReviewRating> GetReviewRatings()
        {
            return db.ReviewRatings;
        }

        // GET: api/ReviewRatings/5
        [ResponseType(typeof(ReviewRating))]
        public IHttpActionResult GetReviewRating(int id)
        {
            ReviewRating reviewRating = db.ReviewRatings.Find(id);
            if (reviewRating == null)
            {
                return NotFound();
            }

            return Ok(reviewRating);
        }

        // PUT: api/ReviewRatings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReviewRating(int id, ReviewRating reviewRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewRating.Id)
            {
                return BadRequest();
            }

            db.Entry(reviewRating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewRatingExists(id))
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

        // POST: api/ReviewRatings
        [ResponseType(typeof(ReviewRating))]
        public IHttpActionResult PostReviewRating(ReviewRating reviewRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReviewRatings.Add(reviewRating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reviewRating.Id }, reviewRating);
        }

        // DELETE: api/ReviewRatings/5
        [ResponseType(typeof(ReviewRating))]
        public IHttpActionResult DeleteReviewRating(int id)
        {
            ReviewRating reviewRating = db.ReviewRatings.Find(id);
            if (reviewRating == null)
            {
                return NotFound();
            }

            db.ReviewRatings.Remove(reviewRating);
            db.SaveChanges();

            return Ok(reviewRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewRatingExists(int id)
        {
            return db.ReviewRatings.Count(e => e.Id == id) > 0;
        }
    }
}