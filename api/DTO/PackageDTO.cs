using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using api.Enums;
namespace API.DTO
{
    public class PackageDetailsDTO
    {
        public int PackageId { get; set; }
        public DateTime DeliveryTime { get; set; }
        public OrderStatus PackageStatus { get; set; }
        public ShipmentData ShippingData { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public List<PackageProductDTO> ProductList { get; set; }
        public double ShippingFees { get; set; }
        public double TotalCharge { get; set; }
    }
}