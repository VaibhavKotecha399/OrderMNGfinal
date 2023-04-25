using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class CartItems
    {
        public CartItems()
        {
            Cart = new HashSet<Cart>();
        }

        public int CartItemId { get; set; }
        public int Pid { get; set; }

        public Products P { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}
