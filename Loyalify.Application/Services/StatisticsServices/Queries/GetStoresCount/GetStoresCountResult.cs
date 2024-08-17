using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStoresCount;

public record GetStoresCountResult(
    HttpStatusCode Status,
    int Count);
