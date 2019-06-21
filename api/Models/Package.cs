
using api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        [Index]
        public int OrderId { get; set; }
        [ForeignKey("Shop")]
        [Index]
        public string ShopId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
