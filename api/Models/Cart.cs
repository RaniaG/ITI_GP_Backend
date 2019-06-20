using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class Cart
    {
        public ApplicationUser User { get; set; }

        public Product Product { get; set; }

        public int Product_Id { get; set; }

        public string User_Id { get; set; }

        public string Variations { get; set; }

        public int Quantity { get; set; }

        public Boolean IsDeleted { get; set; }
    }
}
