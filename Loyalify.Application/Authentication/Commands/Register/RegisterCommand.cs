using ErrorOr;
using MediatR;

namespace Loyalify.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    string Address) : IRequest<ErrorOr<RegisterResult>>;
