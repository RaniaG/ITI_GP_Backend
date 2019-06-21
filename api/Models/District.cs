using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public City City { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
    }
}
