using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.DTOs
{
    public class ProductDTO
    {
        
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        public double? Discount { get; set; }

        public int Quantity { get; set; }

        public string Terms { get; set; }

        public string Variations { get; set; }

        public double? Rating { get; set; }

        public string Images { get; set; }

        public Boolean? Active { get; set; }

        public Boolean? Approved { get; set; }

        public DateTime? PublishTime { get; set; }

        public int? LifeTime { get; set; }

        public int CategoryId { get; set; }
        public string Shop { get; set; }

        public ProductDTO()
        {

        }
        public static ProductDTO ToDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                Quantity = product.Quantity,
                Terms = product.Terms,
                Variations = product.Variations,
                Images = product.Images,
                CategoryId = product.CategoryId,
                Shop = product.ShopID,
                PublishTime = product.PublishTime,
                LifeTime = product.LifeTime,
                Active = product.Active,
                Approved = product.Approved,
                Rating = product.Rating
            };
        }

      }
}