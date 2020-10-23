using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaxComputationAPI.Models;
using TaxComputationSoftware.Models;

namespace TaxComputationAPI.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
     UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();
            });
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<FixedAsset> FixedAsset {get;set;}
         public DbSet<FinancialYear> FinancialYear {get;set;}
        public DbSet<AssetClass> AssetClass {get;set;}
       public DbSet<TrialBalance> TrialBalance {get;set;}
         public DbSet<TrackTrialBalance> TrackTrialBalance { get; set; }
        public DbSet<AssetMapping> AssetMapping { get; set; }
         public DbSet<UserCode> UserCodes { get; set; }
        public DbSet<ItemsMapping> ItemsMapping { get; set; }
    }
}