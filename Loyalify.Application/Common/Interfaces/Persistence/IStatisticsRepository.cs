namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IStatisticsRepository
{
    int GetStoresCount();
    int GetActiveStoresCount();
    int GetOffersCount();
    int GetActiveOffersCount();
    int GetUsersCount();
    decimal GetTakenOffersRatio();
    decimal GetTotalPointsUsed();
    decimal GetAveragePointAmount();
}
