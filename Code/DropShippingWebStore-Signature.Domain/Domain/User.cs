using DropShippingWebStore_Signature.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Domain.Domain
{
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string? Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
