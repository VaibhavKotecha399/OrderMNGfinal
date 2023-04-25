using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class ShipmentStgDTO
    {
        public int ShipStg { get; set; }
        public int? ShipId { get; set; }
        public string ShipCity { get; set; }
        public string ShipArrivalLoc { get; set; }
        public string ShipDepLoc { get; set; }
        public TimeSpan? ShipArrTime { get; set; }
        public TimeSpan? ShipDeptTime { get; set; }

    }
}
