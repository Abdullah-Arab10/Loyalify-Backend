using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Loyalify.Infrastructure.Persistence;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    private readonly UserManager<User> _userManager = userManager;
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
    public async Task BlockUser(string Id)
    {
        var user = await _userManager.FindByIdAsync(Id);
        if (user is not null)
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
}
