namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IPointsRepository
{
    Task<decimal> GetUserPoints(Guid userId);
    Task UpdateUserPoints(Guid userId, decimal points);
}
