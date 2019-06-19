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

        public List<ShipmentData> shipmentDatas { get; set; }
    }
}
