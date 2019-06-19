using model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Order
    {
        public int id { get; set; }
        public PaymentMethods paymentMethod { get; set; }
        public DateTime date { get; set; }
        public OrderStatus status { get; set; }
        public int user_id { get; set; }
        public int shippingData_id { get; set; }
        public ShipmentData shipmentData { get; set; }
        public User user { get; set; }
    }
}
