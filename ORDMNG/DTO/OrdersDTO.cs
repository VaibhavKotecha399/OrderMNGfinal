using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class OrdersDTO
    {
        public int Oid { get; set; }
        public int UserId { get; set; }
        public float? TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }

    }
}
