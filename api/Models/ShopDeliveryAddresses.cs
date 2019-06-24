using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ShopDeliveryAddresses
    {
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("Country")]
        [Index]
        [Required]

        public int CountryID { get; set; }
        public District District { get; set; }
        [ForeignKey("District")]

        public int? DistrictId { get; set; }

        public Shop Shop { get; set; }
        [ForeignKey("Shop")]
        [Key]
        [Column(Order=2)]
        [Required]
        public string ShopId { get; set; }
    }
}