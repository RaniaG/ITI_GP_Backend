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
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        
        [ForeignKey("ShipmentData")]
        public int ShipmentDataId { get; set; }
        public ShipmentData ShipmentData { get; set; }

        public ApplicationUser User { get; set; }

        [MaxLength(128)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
        public List<Package> Packages { get; set; }

        public Boolean IsDeleted { get; set; }
    }
}
