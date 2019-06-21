using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public double? Discount { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Column(TypeName ="nvarchar(max)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Terms { get; set; }
        public Boolean IsDeleted { get; set; }
        [Required]
        public int MinDeliveryTime { get; set; }//in days
        [Required]
        public int MaxDeliveryTime { get; set; }//in days
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Variations { get; set; }//json object as varchar(max)
        public double Rating { get; set; }
        public string Images { get; set; } // urls seperated by delimiter (,)
        public DateTime PublishTime { get; set; }
        public int LifeTime { get; set; }
        public Boolean Active { get; set; }
        public Boolean Approved { get; set; }//by website admin

        [ForeignKey("Shop")]
        [MaxLength(128)]
        public string ShopID { get; set; }
        public Shop Shop { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public List<OrderProduct> OrderProducts { get; set; }
        
        public List<ReviewRating> ReviewRatings { get; set; }

        public List<ApplicationUser> FavouritedByUsers { get; set; }
        public List<Cart> AddedToCarts { get; set; }
    }
}