using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
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
            .Skip((Page - 1) * (int)pageResult)
            .Take((int)pageResult)
            //.Take(Page * (int)pageResult)
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
    public async Task<OfferDetailsDTO> GetOfferDetails(Guid UserId, Guid OfferId)
    {
        var offer = _dbContext.Offers.Where(x => x.Id == OfferId).AsQueryable();
        var offerDetails = new OfferDetailsDTO
        {
            PointAmount = await offer.Select(x => x.PointAmount).FirstOrDefaultAsync(),
            CreatedAt = await offer.Select(x => x.CreatedAt).FirstOrDefaultAsync(),
            Deadline = await offer.Select(x => x.Deadline).FirstOrDefaultAsync(),
            UserPoints = await _dbContext.Users.Where(x => x.Id == UserId).Select(x => x.Points).FirstOrDefaultAsync() 
        };
        var Name = await offer.Select(x => x.Name).FirstOrDefaultAsync();
        if(Name is not null)
        {
            offerDetails.Name = Name;
        }
        var Description = await offer.Select(x => x.Description).FirstOrDefaultAsync();
        if (Description is not null)
        {
            offerDetails.Description = Description;
        }
        var Image = await offer.Select(x => x.Image).FirstOrDefaultAsync();
        if (Image is not null)
        {
            offerDetails.Image = Image;
        }
        return offerDetails;
    }
    public async Task AddTransaction(Transaction transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }
    public bool OfferAlreadyTaken(Guid UserId, Guid OfferId)
    {
        return _dbContext.Transactions.Any(x => x.Offer!.Id == OfferId && x.User!.Id == UserId);
    }
    public async Task<Offer?> GetOfferById(Guid Id)
    {
        return await _dbContext.Offers.FirstOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<List<OffersListUserDTO>> GetPopularOffers()
    {
        var offers = _dbContext.Transactions
            .Select(x => x.Offer)
            .GroupBy(x => x!.Id)
            .OrderByDescending(x => x.Count())
            .Take(5)
            .Select(x => x.Key)
            .ToList();
        return await _dbContext.Offers
            .Where(offer => offers.Contains(offer.Id) && offer.IsActive == true)
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
}
