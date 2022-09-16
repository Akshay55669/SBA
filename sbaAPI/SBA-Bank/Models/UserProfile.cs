using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.Models
{
    public class UserProfile:IdentityUser
    {
        public DateTime dob { get; set; }

        public string panCard { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
