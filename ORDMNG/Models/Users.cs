using System;
using System.Collections.Generic;

namespace ORDMNG.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
            Payment = new HashSet<Payment>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
