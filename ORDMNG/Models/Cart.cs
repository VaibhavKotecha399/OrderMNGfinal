using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public float? Price { get; set; }
        public int? Qty { get; set; }
        public int CartItemId { get; set; }
        public float? TotalPrice { get; set; }

        public CartItems CartItem { get; set; }
        public Users User { get; set; }
    }
}
