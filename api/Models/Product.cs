using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Terms { get; set; }
        public Boolean IsDeleted { get; set; }
        public int MinDeliveryTime { get; set; }//in days
        public int MaxDeliveryTime { get; set; }//in days

        public string Variations { get; set; }//json object as varchar(max)
        public double Rating { get; set; }
        public string Images { get; set; } // urls seperated by delimiter (,)
        public DateTime PublishTime { get; set; }
        public int LifeTime { get; set; }
        public Boolean Active { get; set; }
        public Boolean Approved { get; set; }//by website admin

        public string ShopId { get; set; }

        public int CategoryId { get; set; }

        public Shop Shop { get; set; }

        public Category Category { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public List<ReviewRating> ReviewRatings { get; set; }

        public List<ApplicationUser> FavouritedByUsers { get; set; }
    }
}