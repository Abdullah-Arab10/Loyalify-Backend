using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class CategoryRepository(LoyalifyDbContext dbContext) : ICategoryRepository
{
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task Add(StoreCategory Category)
    {
        await _dbContext.StoreCategories.AddAsync(Category);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<List<StoreCategory>> GetCategories()
    {
        var Categories = await _dbContext.StoreCategories.ToListAsync();
        return Categories;
    }
    public async Task<StoreCategory?> GetCategory(string Name)
    {
        var category = await _dbContext.StoreCategories.FirstOrDefaultAsync(x => x.Name == Name);
        return category;
    }
}
