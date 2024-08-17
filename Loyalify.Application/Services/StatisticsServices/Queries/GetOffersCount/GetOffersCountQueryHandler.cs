using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetOffersCount;

public class GetOffersCountQueryHandler(IStatisticsRepository statisticsRepository):
    IRequestHandler<GetOffersCountQuery, ErrorOr<GetOffersCountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetOffersCountResult>> Handle(GetOffersCountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var count = _statisticsRepository.GetOffersCount();
        return new GetOffersCountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            count);
    }
}
