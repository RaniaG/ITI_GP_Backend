using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double? discount { get; set; }

        public int quantity { get; set; }
        public string description { get; set; }
        public string terms { get; set; }
        public Boolean isDeleted { get; set; }
        public int minDeliveryTime { get; set; }//in days
        public int maxDeliveryTime { get; set; }//in days

        public string variations { get; set; }//json object as varchar(max)
        public double rating { get; set; }
        public string images { get; set; } // urls seperated by delimiter (,)
        public DateTime publishTime { get; set; }
        public int lifeTime { get; set; }
        public Boolean active { get; set; }
        public Boolean approved { get; set; }//by website admin

        public int shop_id { get; set; }

        public int category_id { get; set; }

        public Shop shop { get; set; }

        public Category category { get; set; }
        

    }
}
