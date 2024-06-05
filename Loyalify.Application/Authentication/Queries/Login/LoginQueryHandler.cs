using ErrorOr;
using Loyalify.Application.Common.Interfaces.Authentication;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;

namespace Loyalify.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository) :
    IRequestHandler<LoginQuery,ErrorOr<LoginResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<LoginResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // Validate the password
        if (!_userRepository.CheckPassword(user, query.Password).Result)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user).Result;
        return new LoginResult(token);
    }
}
