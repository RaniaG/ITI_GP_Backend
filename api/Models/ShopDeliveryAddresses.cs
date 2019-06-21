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
        public City City { get; set; }
        [ForeignKey("City")]
        [Key]
        [Column(Order = 1)]
        public int CityId { get; set; }
        public Country Country { get; set; }
        [ForeignKey("Country")]
        [Key]
        [Column(Order = 2)]
        public int CountryID { get; set; }
        public District District { get; set; }
        [ForeignKey("District")]
        [Key]
        [Column(Order = 3)]
        public int DistrictId { get; set; }

        public Shop Shop { get; set; }
        [ForeignKey("Shop")]
        [Key]
        [Column(Order = 4)]
        public string ShopId { get; set; }
    }
}