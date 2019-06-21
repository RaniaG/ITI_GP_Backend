using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderProduct { 
    [ForeignKey("Order")]
    [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
    [ForeignKey("Product")]
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(max)")]
        public string Variations { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
