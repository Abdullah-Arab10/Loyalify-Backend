using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(User user);
}
