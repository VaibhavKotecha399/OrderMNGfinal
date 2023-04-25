using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class CartsDTO
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public float? Price { get; set; }
        public int? Qty { get; set; }
        public int CartItemId { get; set; }
        public float? TotalPrice { get; set; }
    }
}
