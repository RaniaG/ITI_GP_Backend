using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class ShipmentData
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public User user { get; set; }

        public string fullAddress { get; set; }
        public int? postalCode { get; set; }
        public long contactPhone { get; set; }
        public string contactName { get; set; }
        public string contactEmail { get; set; }

        //city id
        public City city { get; set; }

        public int city_id { get; set; }
        //country id
        public Country country { get; set; }
        public int country_id { get; set; }

        public District district { get; set; }
        public int district_id { get; set; }
    }
}
