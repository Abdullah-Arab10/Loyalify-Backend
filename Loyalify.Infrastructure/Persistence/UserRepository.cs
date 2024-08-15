using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Loyalify.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Loyalify.Infrastructure.Persistence;

public class UserRepository(
    UserManager<User> userManager,
    LoyalifyDbContext dbContext) : IUserRepository
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly LoyalifyDbContext _dbContext = dbContext;
    public async Task<IdentityResult> Add(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public User? GetUserByEmail(string email)
    {
        return _userManager.FindByEmailAsync(email).Result;
    }
    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
    public async Task<IdentityResult> AddUserToRole(User user, string Role)
    {
        return await _userManager.AddToRoleAsync(user, Role);
    }
    public async Task BlockUser(int Id)
    {
        var users = await _dbContext.Users
            .Where(x => x.Store != null && x.Store.Id == Id)
            .ToListAsync();
        foreach (var user in users)
        {
            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
        }
    }
    public async Task<User?> GetUserById(Guid Id)
    {
        return await _userManager.FindByIdAsync(Id.ToString());
    }
}
