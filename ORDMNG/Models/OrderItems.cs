using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class OrderItems
    {
        public int Oiid { get; set; }
        public int Pid { get; set; }
        public double? Price { get; set; }
        public int? Qty { get; set; }
        public double? TotalPrice { get; set; }
        public int Oid { get; set; }

        public Orders O { get; set; }
        public Products P { get; set; }
    }
}
