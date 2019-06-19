using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Cart
    {
        public User user { get; set; }

        public Product product { get; set; }

        public int product_id { get; set; }

        public int user_id { get; set; }

        public string variations { get; set; }

        public int quantity { get; set; }
    }
}
