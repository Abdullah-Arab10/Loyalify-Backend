using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IStoreRepository
{
    Task Add(Store store);
}
