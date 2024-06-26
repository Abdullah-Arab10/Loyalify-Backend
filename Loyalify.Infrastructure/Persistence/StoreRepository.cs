using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class StoreRepository(LoyalifyDbContext dbContext) : IStoreRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task Add(Store store)
    {
        await _dbContext.Stores.AddAsync(store);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<StoreCategory?> GetCategory(int Id)
    {
        var cat = await _dbContext.StoreCategories.FirstOrDefaultAsync(x => x.Id == Id);
        return cat;
    }
    public async Task<List<StoresListDTO>> GetStores(int CategoryId) 
    {
        if(CategoryId == 0)
        {
            return await _dbContext.Stores.Select(x => new StoresListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                StoreImage = x.StoreImage
            }).ToListAsync();
        }
        else 
        {
            return await _dbContext.Stores.Where(x => x.Category.Id == CategoryId)
            .Select(x => new StoresListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                StoreImage = x.StoreImage
            }).ToListAsync();
        }
    }
    
}
