using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public async Task<List<StoresListUserDTO>> GetStoresUser(int CategoryId,string Search) 
    {
        if(CategoryId == 0)
        {
            if(Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.IsActive == true)
                .Select(x => new StoresListUserDTO
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
                .Select(x => new StoresListUserDTO
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
                .Select(x => new StoresListUserDTO
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
                .Select(x => new StoresListUserDTO
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
    /*public async Task<Guid> GetStoreUser(int Id)
    {
        var userId = await _dbContext.Stores
            .Where(x => x.Id == Id)
            .Select(x => x.User.Id)
            .FirstOrDefaultAsync();
        return userId;
    }*/
    public async Task<List<StoresListAdminDTO>> GetStoresAdmin(int CategoryId, string Search)
    {
        if (CategoryId == 0)
        {
            if (Search is null)
            {
                return await _dbContext.Stores
                .Select(StoreForm()).ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => (x.Name.Contains(Search) ||
                x.Description.Contains(Search)))
                .Select(StoreForm()).ToListAsync();
            }
        }
        else
        {
            if (Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId)
                .Select(StoreForm()).ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId
                && (x.Name.Contains(Search) || x.Description.Contains(Search)))
                .Select(StoreForm()).ToListAsync();
            }
        }
    }
    private static Expression<Func<Store, StoresListAdminDTO>> StoreForm()
    {
        return x => new StoresListAdminDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Address = x.Address,
            PhoneNumber = x.PhoneNumber,
            PointRatio = x.PointRatio,
            CategoryId = x.Category.Id,
            CategoryName = x.Category.Name,
            StoreImage = x.StoreImage,
            CoverImage = x.CoverImage,
            IsActive = x.IsActive
        };
    }
    public async Task Update(UpdateStoreDTO store,int Id)
    {
        var eStore = await _dbContext.Stores.FindAsync(Id);
        if(eStore is not null && eStore.IsActive != false)
        {
            if (store.Name is not null && store.Name != eStore.Name)
            {
                eStore.Name = store.Name;
            }
            if (store.Description is not null && store.Description != eStore.Description)
            {
                eStore.Description = store.Description;
            }
            if (store.Address is not null && store.Address != eStore.Address)
            {
                eStore.Address = store.Address;
            }
            if (store.PhoneNumber is not null && store.PhoneNumber != eStore.PhoneNumber)
            {
                eStore.PhoneNumber = store.PhoneNumber;
            }
            if (store.CoverImage is not null) 
            {
                eStore.CoverImage = store.CoverImage;
            }
            if (store.StoreImage is not null) 
            {
                eStore.StoreImage = store.StoreImage;
            }
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task<GetStoreInfoDTO?> GetStoreInfo(int storeId)
    {
        return await _dbContext.Stores.Where(x => x.Id == storeId)
            .Select(x => new GetStoreInfoDTO
            {
                Name = x.Name,
                Description = x.Description,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                CoverImage = x.CoverImage,
                StoreImage = x.StoreImage,
                CategoryId = x.Category.Id,
                IsActive = x.IsActive
            }).FirstOrDefaultAsync();
    }
    public async Task<bool> StoreIsActive(Guid Id)
    {
        var storeId = await _dbContext.Users
            .Where(x => x.Id == Id)
            .Select(x => x.Store!.Id).FirstOrDefaultAsync();
        return await _dbContext.Stores
            .Where(x => x.Id == storeId && x.IsActive == true)
            .AnyAsync();
    }
    public async Task<decimal> GetStorePointRatio(Guid Id)
    {
        var storeId = await _dbContext.Users
            .Where(x => x.Id == Id)
            .Select(x => x.Store!.Id).FirstOrDefaultAsync();
        return await _dbContext.Stores.Where(x => x.Id == storeId)
            .Select(x => x.PointRatio).FirstOrDefaultAsync();
    }
    public async Task<List<StoresListUserDTO>> GetPopularStores()
    {
        var offers = _dbContext.Transactions
            .GroupBy(x => x.Offer!.Store.Id)
            .OrderByDescending(x => x.Count())
            .Take(5)
            .Select(x => x.Key)
            .ToList();
        var topStores = await _dbContext.Offers
            .Where(offer => offers.Contains(offer.Store.Id))
            .Select(offer => offer.Store)
            .Distinct()
            .Select(x => new StoresListUserDTO
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                StoreImage = x.StoreImage
            }).ToListAsync();
        return topStores;
    }
    public async Task<Store?> GetStoreById(int Id)
    {
        return await _dbContext.Stores.FirstOrDefaultAsync(x => x.Id == Id);
    }
    public async Task<int> GetUserStoreId(Guid Id)
    {
        return await _dbContext.Users.Where(x => x.Id == Id)
            .Select(x => x.Store!.Id).FirstOrDefaultAsync();
    }
}