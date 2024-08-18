using System.Net;

namespace Loyalify.Application.Services.PointsServices.Commands.AddPoints;

public record AddPointsResult(
    HttpStatusCode Status,
    string Message,
    string DeviceToken);
