
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
        // Bhanu -- 16/09/2022-- UserProfile table with all props
        public DbSet<UserProfile> userProfiles { get; set; }
        // Akshay -- 16/09/2022-- AccountDetails table with all props
      public DbSet<AccountInfo> accountInfos { get; set; }
        // Bhanu -- 16/09/2022-- Statement table with all props
        public DbSet<Statement> statements { get; set; }

        // Akshay -- 16/09/2022-- Support table with all props
        public DbSet<Support> supports { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

    }
}
