using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ShopVisit
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public Shop Shop { get; set; }
        [ForeignKey("Shop")]
        [MaxLength(128)]
        public string ShopId { get; set; }
    }
}