using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTakenOffersRatio;

public record GetTakenOffersRatioResult(
    HttpStatusCode Status,
    decimal Ratio);
