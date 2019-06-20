using api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public string UserId { get; set; }
        public int ShippingDataId { get; set; }
        public ShipmentData ShipmentData { get; set; }
        public ApplicationUser User { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public List<Package> Packages { get; set; }
    }
}
