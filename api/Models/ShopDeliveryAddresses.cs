using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class ShopDeliveryAddresses
    {
        public City City { get; set; }
        public int CityId { get; set; }
        public Country Country { get; set; }
        public int CountryID { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }

        public Shop Shop { get; set; }
        public string ShopId { get; set; }
    }
}