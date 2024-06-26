using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface ICategoryRepository
{
    Task Add(StoreCategory Category);
    Task<List<StoreCategory>> GetCategories();
    Task<StoreCategory?> GetCategory(string Name);
}
