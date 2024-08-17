using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetOffersCount;

public record GetOffersCountResult(
    HttpStatusCode Status,
    int Count);
