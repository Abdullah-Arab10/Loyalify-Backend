using Loyalify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Loyalify.Infrastructure.Data;

public class LoyalifyDbContext(DbContextOptions<LoyalifyDbContext> options)
    : IdentityDbContext<User,IdentityRole<Guid>,Guid>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().Ignore(x => x.TwoFactorEnabled)
                                  .Ignore(x => x.LockoutEnd)
                                  .Ignore(x => x.LockoutEnabled)
                                  .Ignore(x => x.AccessFailedCount)
                                  .Ignore(x => x.PhoneNumberConfirmed)
                                  .Ignore(x => x.UserName)
                                  .Ignore(x => x.SecurityStamp)
                                  .Ignore(x => x.ConcurrencyStamp)
                                  .Ignore(x => x.EmailConfirmed);
        builder.Entity<IdentityRole<Guid>>().Ignore(x => x.NormalizedName);
        RolesSeeder(builder);

        base.OnModelCreating(builder);
    }

    private static void RolesSeeder(ModelBuilder builder)
    {
        builder.Entity<IdentityRole<Guid>>().HasData(
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "StoreManager",
                        NormalizedName = "STOREMANAGER"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Cashier",
                        NormalizedName = "CASHIER"
                    });
    }
}
