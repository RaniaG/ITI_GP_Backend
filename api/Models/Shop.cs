using api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Shop
    {
        [MaxLength(128)]
        [Key,ForeignKey("User")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName ="nvarchar(max)")]
        public string Photo { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string Cover { get; set; }
        public double Rating { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string About { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public string Policy { get; set; }
        public SubscriptionType Subscription { get; set; }
        public Boolean IsDeleted { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        //Address
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("City")]

        public int CityId { get; set; }
        [ForeignKey("District")]

        public int DistrictId { get; set; }

        [InverseProperty("Shop")]
        [Required]
        public ApplicationUser User { get; set; }
        public List<Product> Products { get; set; }
        public List<Package> Packages { get; set; }
        public List<ShopVisit> VisitedBy { get; set; }
        public List<ReviewRating> ReviewRatings { get; set; }
        [InverseProperty("FollowedShops")]
        public List<ApplicationUser> FollowedBy { get; set; }

    }
}
