using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTotalPointsUsed;

public class GetTotalPointsUsedQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetTotalPointsUsedQuery, ErrorOr<GetTotalPointsUsedResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetTotalPointsUsedResult>> Handle(GetTotalPointsUsedQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new GetTotalPointsUsedResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            _statisticsRepository.GetTotalPointsUsed());
    }
}
