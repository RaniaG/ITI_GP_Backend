using model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Package
    {
        public int id { get; set; }
        public Shop shop { get; set; }
        public Order order { get; set; }
        public int order_id { get; set; }
        public int shop_id { get; set; }
        public OrderStatus status { get; set; }
        public DateTime deliveryTime { get; set; }
    }
}
