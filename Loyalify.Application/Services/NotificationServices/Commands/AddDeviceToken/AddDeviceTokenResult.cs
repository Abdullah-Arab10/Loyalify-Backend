using System.Net;

namespace Loyalify.Application.Services.NotificationServices.Commands.AddDeviceToken;

public record AddDeviceTokenResult(
    HttpStatusCode Status,
    string Message);
