using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTotalPointsUsed;

public record GetTotalPointsUsedResult(
    HttpStatusCode Status,
    decimal Points);
