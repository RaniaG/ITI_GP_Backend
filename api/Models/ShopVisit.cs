using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class ShopVisit
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public Shop Shop { get; set; }
        public string Shop_Id { get; set; }
    }
}