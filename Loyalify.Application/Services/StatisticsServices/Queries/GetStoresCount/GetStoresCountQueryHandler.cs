using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStoresCount;

public class GetStoresCountQueryHandler(IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetStoresCountQuery, ErrorOr<GetStoresCountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetStoresCountResult>> Handle(GetStoresCountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var count = _statisticsRepository.GetStoresCount();
        return new GetStoresCountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            count);
    }
}
