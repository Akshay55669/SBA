
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBA_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.DbContext
{
    public class SBAdbContext:IdentityDbContext
    {
        public SBAdbContext(DbContextOptions<SBAdbContext>options):base(options)
        {

        }
       public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<AccountDetails> accountDetails { get; set; }

    }
}
