using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetAveragePointAmount;

public record GetAveragePointAmountResult(
    HttpStatusCode Status,
    decimal Points);
