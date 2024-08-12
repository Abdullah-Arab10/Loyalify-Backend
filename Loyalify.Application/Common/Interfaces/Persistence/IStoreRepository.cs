using Loyalify.Application.Common.DTOs;
using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IStoreRepository
{
    Task Add(Store store);
    Task<StoreCategory?> GetCategory(int Id);
    Task<List<StoresListUserDTO>> GetStoresUser(int CategoryId, string Search);
    Task<bool> DeactivateStore(int Id);
    Task<Guid> GetStoreUser(int Id);
    Task<List<StoresListAdminDTO>> GetStoresAdmin(int CategoryId, string Search);
    Task<decimal> GetStoreById(int Id);
    Task Update(UpdateStoreDTO Store,int Id);
    Task<GetStoreInfoDTO?> GetStoreInfo(int Id);
}
