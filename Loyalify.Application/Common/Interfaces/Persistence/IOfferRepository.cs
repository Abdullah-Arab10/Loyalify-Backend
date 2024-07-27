using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IOfferRepository
{
    Task Add(Offer offer);
    Task<Store?> GetOfferStore(int Id);
    Task UpdateIsActive(Guid offerId);
}
