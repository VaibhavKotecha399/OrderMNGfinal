using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class Products
    {
        public Products()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int Pid { get; set; }
        public string ProductName { get; set; }
        public string Seller { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public int Qty { get; set; }
        public string Category { get; set; }

        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
