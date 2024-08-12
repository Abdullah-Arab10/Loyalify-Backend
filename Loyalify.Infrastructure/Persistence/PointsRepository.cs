using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class PointsRepository(LoyalifyDbContext dbContext) : IPointsRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task<decimal> GetUserPoints(Guid userId)
    {
        decimal points = await _dbContext.Users.Where(x => x.Id == userId).Select(x => x.Points).FirstOrDefaultAsync();
        return points;
    }
    public async Task UpdateUserPoints(Guid userId, decimal points)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user != null)
        {
            user.Points += points;
            await _dbContext.SaveChangesAsync();
        }
    }
}

