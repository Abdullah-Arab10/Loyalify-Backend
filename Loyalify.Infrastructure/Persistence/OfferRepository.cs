using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class OfferRepository(
    LoyalifyDbContext dbContext) 
    : IOfferRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task Add(Offer offer)
    {
        await _dbContext.AddAsync(offer);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<Store?> GetOfferStore(int Id)
    {
        var store = await _dbContext.Stores
            .Where(x => x.Id == Id)
            .FirstOrDefaultAsync();
        return store;
    }
    public async Task UpdateIsActive(Guid offerId)
    {
        var offer = await _dbContext.Offers.FindAsync(offerId);
        if (offer != null)
        {
            offer.IsActive = false;
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task<List<OffersListUserDTO>> GetAllOffersUser(int Page)
    {
        var pageResult = 10f;
        return await _dbContext.Offers
            .Where(x => x.IsActive == true && x.Store.IsActive == true)
            .OrderByDescending(x => x.Id)
            .Take(Page * (int)pageResult)
            .Select(x => new OffersListUserDTO
            {
                Id = x.Id,
                OfferName = x.Name,
                OfferImage = x.Image,
                StoreName = x.Store.Name,
                StoreImage = x.Store.StoreImage,
                PointAmount = x.PointAmount
            }).ToListAsync();
    }
    public async Task<List<OffersListUserDTO>> GetStoreOffers(int Id)
    {
        return await _dbContext.Offers
            .Where(x => x.Store.Id == Id && x.IsActive == true)
            .Select(x => new OffersListUserDTO
            {
                Id = x.Id,
                OfferName = x.Name,
                OfferImage = x.Image,
                StoreName = x.Store.Name,
                StoreImage = x.Store.StoreImage,
                PointAmount = x.PointAmount
            }).ToListAsync();
    }
    public OfferDetailsDTO GetOfferDetails(Guid UserId, Guid OfferId)
    {
        var offer = _dbContext.Offers.Where(x => x.Id == OfferId).AsQueryable();
        var offerDetails = new OfferDetailsDTO 
        {
            PointAmount = offer.Select(x => x.PointAmount).FirstOrDefault(),
            CreatedAt = offer.Select(x => x.CreatedAt).FirstOrDefault(),
            Deadline = offer.Select(x => x.Deadline).FirstOrDefault(),
            UserPoints = _dbContext.Users.Where(x => x.Id == UserId).Select(x => x.Points).FirstOrDefault() 
        };
        var Name = offer.Select(x => x.Name).FirstOrDefault();
        if(Name is not null)
        {
            offerDetails.Name = Name;
        }
        var Description = offer.Select(x => x.Description).FirstOrDefault();
        if (Description is not null)
        {
            offerDetails.Description = Description;
        }
        var Image = offer.Select(x => x.Image).FirstOrDefault();
        if (Image is not null)
        {
            offerDetails.Image = Image;
        }
        return offerDetails;
    }
}
