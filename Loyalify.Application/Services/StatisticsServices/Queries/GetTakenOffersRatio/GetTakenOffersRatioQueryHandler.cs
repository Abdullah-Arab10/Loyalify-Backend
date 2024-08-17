using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTakenOffersRatio;

public class GetTakenOffersRatioQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetTakenOffersRatioQuery, ErrorOr<GetTakenOffersRatioResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetTakenOffersRatioResult>> Handle(GetTakenOffersRatioQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var ratio = _statisticsRepository.GetTakenOffersRatio();
        return new GetTakenOffersRatioResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            ratio);
    }
}
