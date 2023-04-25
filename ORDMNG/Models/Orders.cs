using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
            Payment = new HashSet<Payment>();
        }

        public int Oid { get; set; }
        public int UserId { get; set; }
        public float? TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }

        public Users User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
