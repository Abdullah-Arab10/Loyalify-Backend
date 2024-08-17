using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveStoresCount;

public record GetActiveStoresCountResult(
    HttpStatusCode Status,
    int Count);
