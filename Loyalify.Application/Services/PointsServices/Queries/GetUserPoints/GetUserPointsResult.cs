using System.Net;

namespace Loyalify.Application.Services.PointsServices.Queries.GetUserPoints;

public record GetUserPointsResult(
    HttpStatusCode Status,
    decimal Points);


