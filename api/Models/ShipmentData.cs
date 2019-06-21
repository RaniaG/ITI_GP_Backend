using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ShipmentData
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [ForeignKey("User")]
        [Column(Order = 2)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string FullAddress { get; set; }
        public int? PostalCode { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]

        public string ContactName { get; set; }
        [Required]

        public string ContactEmail { get; set; }

        //city id
        public City City { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }

        //country id
        public Country Country { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public District District { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
    }
}
