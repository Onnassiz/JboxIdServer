using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServerWithAspNetIdentity.Models;

namespace IdentityServerWithAspNetIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var now = DateTime.UtcNow;

            //Person table
            foreach (var item in ChangeTracker.Entries<ApplicationUser>().Where(e => e.State == EntityState.Modified))
            {
                item.Property("DateUpdated").CurrentValue = now;
            }
            foreach (var item in ChangeTracker.Entries<ApplicationUser>().Where(e => e.State == EntityState.Added))
            {
                item.Property("DateCreated").CurrentValue = now;
            }

            return base.SaveChanges();
        }
    }
}
