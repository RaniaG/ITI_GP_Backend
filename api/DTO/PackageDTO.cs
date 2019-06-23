using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using api.Enums;
namespace API.DTO
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public ProductDTO[] ProductList { get; set; }
    }
}