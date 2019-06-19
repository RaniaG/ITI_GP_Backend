using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class OrderProduct
    {
        public int order_id { get; set; }
        public int product_id { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
        public string variations { get; set; }
        public int quantity { get; set; }
    }
}
