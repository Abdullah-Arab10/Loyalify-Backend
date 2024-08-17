using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetAveragePointAmount;

public class GetAveragePointAmountQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetAveragePointAmountQuery, ErrorOr<GetAveragePointAmountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetAveragePointAmountResult>> Handle(GetAveragePointAmountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new GetAveragePointAmountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            _statisticsRepository.GetAveragePointAmount());
    }
}
