using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
    public async Task<List<StoresListDTO>> GetStores(int CategoryId,string Search) 
    {
        if(CategoryId == 0)
        {
            if(Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.IsActive == true)
                .Select(x => new StoresListDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    StoreImage = x.StoreImage
                }).ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => x.IsActive == true && 
                (x.Name.Contains(Search) || x.Description.Contains(Search)))
                .Select(x => new StoresListDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    StoreImage = x.StoreImage
                }).ToListAsync();
            }
        }
        else 
        {
            if(Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId && x.IsActive == true)
                .Select(x => new StoresListDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    StoreImage = x.StoreImage
                }).ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId && x.IsActive == true
                && (x.Name.Contains(Search) || x.Description.Contains(Search)))
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
    public async Task<bool> DeactivateStore(int Id)
    {
        var store = await _dbContext.Stores.FirstOrDefaultAsync(x => x.Id == Id);
        if(store is not null)
        {
            if(store.IsActive == true)
            {
                store.IsActive = false;
                await _dbContext.SaveChangesAsync();
                return false;
            }
            else
            {
                store.IsActive = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        else
        {
            await _dbContext.SaveChangesAsync();
            return false;
        }
        
    }
    public async Task<Guid> GetStoreUser(int Id)
    {
        var userId = await _dbContext.Stores.Where(x => x.Id == Id).Select(x => x.User.Id).FirstOrDefaultAsync();
        return userId;
    }
}
