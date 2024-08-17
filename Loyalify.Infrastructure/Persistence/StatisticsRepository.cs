using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Infrastructure.Data;

namespace Loyalify.Infrastructure.Persistence;

public class StatisticsRepository(LoyalifyDbContext dbContext): IStatisticsRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public int GetStoresCount()
    {
        return _dbContext.Stores.Count();
    }
    public int GetActiveStoresCount()
    {
        return _dbContext.Stores.Where(x => x.IsActive == true).Count();
    }
    public int GetOffersCount()
    {
        return _dbContext.Offers.Count();
    }
    public int GetActiveOffersCount()
    {
        return _dbContext.Offers.Where(x => x.IsActive == true).Count();
    }
    public int GetUsersCount()
    {
        return _dbContext.Users.Count();
    }
    public decimal GetTakenOffersRatio()
    {
        var TakenOffersCount = _dbContext.Transactions.GroupBy(x => x.Offer).Count();
        var offersCount = _dbContext.Offers.Count();
        decimal ratio = (decimal)TakenOffersCount / offersCount * 100;
        return ratio;
    }
    public decimal GetTotalPointsUsed()
    {
        decimal totalPointsUsed = 0;
        var PointAmountForEveryOffer = _dbContext.Transactions.Select(x => x.Offer!.PointAmount).ToList();
        foreach(var pointAmount in PointAmountForEveryOffer)
        {
            totalPointsUsed += pointAmount;
        }
        return totalPointsUsed;
    }
    public decimal GetAveragePointAmount()
    {
        decimal totalPointAmount = 0;
        var PointAmountForEveryOffer = _dbContext.Offers.Select(x => x.PointAmount).ToList();
        foreach (var pointAmount in PointAmountForEveryOffer)
        {
            totalPointAmount += pointAmount;
        }
        var offersCount = _dbContext.Offers.Count();
        if(totalPointAmount == 0)
        {
            return 0;
        }
        return totalPointAmount / offersCount;
    }
}
