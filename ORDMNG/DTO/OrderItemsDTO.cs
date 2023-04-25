using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class OrderItemsDTO
    {
        public int Oiid { get; set; }
        public int Pid { get; set; }
        public double? Price { get; set; }
        public int? Qty { get; set; }
        public double? TotalPrice { get; set; }
        public int Oid { get; set; }
    }
}
