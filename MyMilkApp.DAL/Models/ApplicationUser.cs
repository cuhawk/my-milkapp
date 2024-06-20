using Microsoft.AspNetCore.Identity;
using MyMilkApp.DAL.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMilkApp.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public UserStatus Status { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
