using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class ShipmentData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string FullAddress { get; set; }
        public int? PostalCode { get; set; }
        public string ContactPhone { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }

        //city id
        public City city { get; set; }

        public int CityId { get; set; }
        //country id
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public District District { get; set; }
        public int DistrictId { get; set; }
    }
}
