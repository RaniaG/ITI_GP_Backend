using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class ReviewRating
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Review { get; set; }
        public string DelieveryServiceReview { get; set; }
        public string ShopServiceReview { get; set; }
        public int ProductRating { get; set; }
        public int ShopRating { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Shop Shop { get; set; }
        public string ShopId { get; set; }



    }
}
