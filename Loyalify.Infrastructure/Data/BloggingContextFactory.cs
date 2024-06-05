using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Loyalify.Infrastructure.Data;

public class BloggingContextFactory : IDesignTimeDbContextFactory<LoyalifyDbContext>
{
    public LoyalifyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LoyalifyDbContext>();
        optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Loyalify;Trusted_Connection=true;TrustServerCertificate=true;");

        return new LoyalifyDbContext(optionsBuilder.Options);
    }
}