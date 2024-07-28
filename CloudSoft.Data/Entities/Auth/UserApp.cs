using Microsoft.AspNetCore.Identity;
using System;

namespace CloudSoft.Data.Entities.Auth
{
    public class UserApp 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
