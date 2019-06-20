using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models
{
    public class Shop
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Cover { get; set; }
        public int Rating { get; set; }
        public string About { get; set; }
        public string Policy { get; set; }
        public int Subscription { get; set; }
        public char IsDeleted { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        //Address
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public int CountryId { get; set; }

        public int CityId { get; set; }
        public int DistrictId { get; set; }

        public ApplicationUser User { get; set; }
        public List<Product> Products { get; set; }
        public List<Package> Packages { get; set; }

        public List<ReviewRating> ReviewRatings { get; set; }



    }
}
