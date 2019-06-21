using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Country Country { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public List<District> Districts { get; set; }
    }
}
