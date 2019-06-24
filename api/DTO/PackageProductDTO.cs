using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DTO
{
    public class PackageProductDTO
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public int Quantity { get; set; }
        public string Variations { get; set; }//json object as varchar(max)
        public string Images { get; set; } // urls seperated by delimiter (,)
    }
}