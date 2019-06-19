using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
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

        public User user { get; set; }

        public int user_id { get; set; }
        public Product  product { get; set; }
        public int product_id { get; set; }
        public Shop shop { get; set; }
        public int shop_id { get; set; }



    }
}
