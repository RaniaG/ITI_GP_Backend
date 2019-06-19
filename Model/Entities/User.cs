using model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Entities
{
    public class User
    {
        public int id { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string UserName { get; set; }

        public string Photo { get; set; }

        public string CoverPhoto { get; set; }

        public string Email { get; set; }

        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public string Password { get; set; }

        public virtual Shop Shop { get; set; }

        public List<ShipmentData> shipmentDatas { get; set; }
    }
}
