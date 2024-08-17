using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveOffersCount;

public class GetActiveOffersCountQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetActiveOffersCountQuery, ErrorOr<GetActiveOffersCountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetActiveOffersCountResult>> Handle(GetActiveOffersCountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var count = _statisticsRepository.GetActiveOffersCount();
        return new GetActiveOffersCountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            count);
    }
}
