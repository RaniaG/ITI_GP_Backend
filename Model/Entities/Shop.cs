using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Cover { get; set; }
        public int Rating { get; set; }
        public string About { get; set; }
        public string Policy { get; set; }
        public int Subscription { get; set; }
        public char IsDeleted { get; set; }

        //Address
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }

        public virtual User User { get; set; }

    }
}
