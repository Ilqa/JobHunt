using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHunt.Database
{
    public class ApplicationContext : IdentityDbContext<User, UserType, int> //, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>> //, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserEducation> UserEducation { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync();

        }
    }
}