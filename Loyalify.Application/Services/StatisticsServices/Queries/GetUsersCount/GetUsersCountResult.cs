using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetUsersCount;

public record GetUsersCountResult(
    HttpStatusCode Status,
    int Count);
