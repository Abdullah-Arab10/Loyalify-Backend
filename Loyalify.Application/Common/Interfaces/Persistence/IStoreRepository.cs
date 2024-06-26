using Loyalify.Application.Common.DTOs;
using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IStoreRepository
{
    Task Add(Store store);
    Task<StoreCategory?> GetCategory(int Id);
    Task<List<StoresListDTO>> GetStores(int CategoryId);
}
