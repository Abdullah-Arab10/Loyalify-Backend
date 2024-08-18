using Loyalify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Loyalify.Infrastructure.Data;

public class LoyalifyDbContext(DbContextOptions<LoyalifyDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
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
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreCategory> StoreCategories { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<NotificationToken> NotificationTokens { get; set; }
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
        AdminSeeder(builder);
        builder.Entity<StoreCategory>().HasData(
            new StoreCategory
            {
                Id = -1,
                Name = "All",
            }
        );
        builder.Entity<User>()
                .Property(s => s.Points)
                .HasColumnType("decimal(18, 3)");
        base.OnModelCreating(builder);

        builder.Entity<Offer>()
                .Property(s => s.PointAmount)
                .HasColumnType("decimal(18, 3)");
        base.OnModelCreating(builder);

        builder.Entity<Store>()
                .Property(s => s.PointRatio)
                .HasColumnType("decimal(18, 3)");
        base.OnModelCreating(builder);
    }
    private static void AdminSeeder(ModelBuilder builder)
    {
        IdentityRole<Guid> role1 = RolesSeeder(builder);
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Admin",
            LastName = "Admin",
            Email = "Admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            UserName = "Admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            PhoneNumber = "9817289341",
            Address = "Nabek",
            IsActive = true,
        };
        var password = new PasswordHasher<User>();
        var hashed = password.HashPassword(user, "1234567");
        user.PasswordHash = hashed;
        builder.Entity<User>().HasData(user);
        builder.Entity<IdentityUserRole<Guid>>().HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = role1.Id,
                UserId = user.Id
            }
        );
    }
    private static IdentityRole<Guid> RolesSeeder(ModelBuilder builder)
    {
        var role1 = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        };
        var role2 = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = "User",
            NormalizedName = "USER"
        };
        var role3 = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = "StoreManager",
            NormalizedName = "STOREMANAGER"
        };
        var role4 = new IdentityRole<Guid>()
        {
            Id = Guid.NewGuid(),
            Name = "Cashier",
            NormalizedName = "CASHIER"
        };
        builder.Entity<IdentityRole<Guid>>().HasData(role1);
        builder.Entity<IdentityRole<Guid>>().HasData(role2);
        builder.Entity<IdentityRole<Guid>>().HasData(role3);
        builder.Entity<IdentityRole<Guid>>().HasData(role4);
        return role1;
    }
}