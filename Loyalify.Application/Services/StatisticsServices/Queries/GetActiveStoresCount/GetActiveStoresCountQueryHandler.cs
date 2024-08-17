using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveStoresCount;

public class GetActiveStoresCountQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetActiveStoresCountQuery, ErrorOr<GetActiveStoresCountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;

    public async Task<ErrorOr<GetActiveStoresCountResult>> Handle(GetActiveStoresCountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var count = _statisticsRepository.GetActiveStoresCount();
        return new GetActiveStoresCountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            count);
    }
}
