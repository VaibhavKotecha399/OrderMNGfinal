using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class ShipmentStg
    {
        public int ShipStg { get; set; }
        public int? ShipId { get; set; }
        public string ShipCity { get; set; }
        public string ShipArrivalLoc { get; set; }
        public string ShipDepLoc { get; set; }
        public TimeSpan? ShipArrTime { get; set; }
        public TimeSpan? ShipDeptTime { get; set; }

        public Shipping Ship { get; set; }
    }
}
