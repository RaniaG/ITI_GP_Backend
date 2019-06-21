using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ReviewRating
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Review { get; set; }
        public string DelieveryServiceReview { get; set; }
        public string ShopServiceReview { get; set; }
        public double ProductRating { get; set; }
        public double ShopRating { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Product")]

        public int ProductId { get; set; }
        public Shop Shop { get; set; }
        [ForeignKey("Shop")]

        public string ShopId { get; set; }



    }
}
