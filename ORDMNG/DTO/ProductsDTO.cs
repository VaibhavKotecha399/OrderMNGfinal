using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class ProductsDTO
    {
        public int Pid { get; set; }
        public string ProductName { get; set; }
        public string Seller { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public int Qty { get; set; }
        public string Category { get; set; }

    }
}
