﻿using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Loyalify.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class OfferRepository(
    LoyalifyDbContext dbContext,
    IDateTimeProvider dateTimeProvider) 
    : IOfferRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
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
}