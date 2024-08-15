using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.Authentication.Commands.RegisterACashier;

public record RegisterACashierCommand(
    Guid StoreManagerId,
    string FirstName,
    string LastName,
    string Email,
    string Password): IRequest<ErrorOr<RegisterACashierResult>>;
