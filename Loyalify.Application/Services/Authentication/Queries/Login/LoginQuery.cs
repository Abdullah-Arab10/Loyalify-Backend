using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<LoginResult>>;
