using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Cart
    {
        public ApplicationUser User { get; set; }

        public Product Product { get; set; }
        [ForeignKey("Product")]
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        [ForeignKey("User")]
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
        [Required]
        public string Variations { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Boolean IsDeleted { get; set; }
    }
}
