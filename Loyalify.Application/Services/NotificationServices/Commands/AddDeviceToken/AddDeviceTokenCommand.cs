using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.NotificationServices.Commands.AddDeviceToken;

public record AddDeviceTokenCommand(
    Guid Id,
    string DeviceToken) : IRequest<ErrorOr<AddDeviceTokenResult>>;
