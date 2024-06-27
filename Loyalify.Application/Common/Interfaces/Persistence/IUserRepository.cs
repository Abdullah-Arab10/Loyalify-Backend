using Loyalify.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Loyalify.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    Task<IdentityResult> Add(User user,string password);
    Task<bool> CheckPassword(User user, string password);
    Task<IdentityResult> AddUserToRole(User user, string Role);
    Task BlockUser(string Id);
}
