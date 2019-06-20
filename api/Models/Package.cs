
using api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class Package
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public string ShopId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
