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
    public async Task<Guid> GetStoreUser(int Id)
    {
        var userId = await _dbContext.Stores.Where(x => x.Id == Id).Select(x => x.User.Id).FirstOrDefaultAsync();
        return userId;
    }
    public async Task<List<StoresListAdminDTO>> GetStoresAdmin(int CategoryId, string Search)
    {
        if (CategoryId == 0)
        {
            if (Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.IsActive == true)
                .Select(x => new StoresListAdminDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    UserId = x.User.Id,
                    CategoryId = x.Category.Id,
                    StoreImage = x.StoreImage,
                    CoverImage = x.CoverImage,
                    IsActive = x.IsActive
                })
                .ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => x.IsActive == true &&
                (x.Name.Contains(Search) || x.Description.Contains(Search)))
                .Select(x => new StoresListAdminDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    UserId = x.User.Id,
                    CategoryId = x.Category.Id,
                    StoreImage = x.StoreImage,
                    CoverImage = x.CoverImage,
                    IsActive = x.IsActive
                })
                .ToListAsync();
            }
        }
        else
        {
            if (Search is null)
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId && x.IsActive == true)
                .Select(x => new StoresListAdminDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    UserId = x.User.Id,
                    CategoryId = x.Category.Id,
                    StoreImage = x.StoreImage,
                    CoverImage = x.CoverImage,
                    IsActive = x.IsActive
                })
                .ToListAsync();
            }
            else
            {
                return await _dbContext.Stores
                .Where(x => x.Category.Id == CategoryId && x.IsActive == true
                && (x.Name.Contains(Search) || x.Description.Contains(Search)))
                .Select(x => new StoresListAdminDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    UserId = x.User.Id,
                    CategoryId = x.Category.Id,
                    StoreImage = x.StoreImage,
                    CoverImage = x.CoverImage,
                    IsActive = x.IsActive
                })
                .ToListAsync();
            }
        }
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
                UserId = x.User.Id,
                IsActive = x.IsActive

            }).FirstOrDefaultAsync();

    }
}
