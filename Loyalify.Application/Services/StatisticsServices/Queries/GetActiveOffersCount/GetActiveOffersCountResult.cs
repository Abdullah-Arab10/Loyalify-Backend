using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveOffersCount;

public record GetActiveOffersCountResult(
    HttpStatusCode Status,
    int Count);
