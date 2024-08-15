using Loyalify.Application.Common.DTOs;
using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IOfferRepository
{
    Task Add(Offer offer);
    Task<Store?> GetOfferStore(int Id);
    Task UpdateIsActive(Guid offerId);
    Task<List<OffersListUserDTO>> GetAllOffersUser(int Page);
    Task<List<OffersListUserDTO>> GetStoreOffers(int Id);
    Task<OfferDetailsDTO> GetOfferDetails(Guid UserId,Guid OfferId);
    Task AddTransaction(Transaction transaction);
    bool OfferAlreadyTaken(Guid UserId, Guid OfferId);
    Task<Offer?> GetOfferById(Guid Id);
    Task<List<OffersListUserDTO>> GetPopularOffers();
}
