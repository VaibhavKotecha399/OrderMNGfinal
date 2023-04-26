using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORDMNG.DTO
{
    public class UsersDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string Phone { get; set; }
        public string[] UserType { get; set; }
    }
}
