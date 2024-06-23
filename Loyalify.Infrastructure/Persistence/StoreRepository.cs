using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;

namespace Loyalify.Infrastructure.Persistence;

public class StoreRepository(LoyalifyDbContext dbContext) : IStoreRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task Add(Store store)
    {
        await _dbContext.Stores.AddAsync(store);
        await _dbContext.SaveChangesAsync();
    }
}
