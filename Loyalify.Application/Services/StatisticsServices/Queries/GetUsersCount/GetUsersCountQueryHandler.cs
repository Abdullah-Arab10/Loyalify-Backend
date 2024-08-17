using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetUsersCount;

public class GetUsersCountQueryHandler(
    IStatisticsRepository statisticsRepository) :
    IRequestHandler<GetUsersCountQuery, ErrorOr<GetUsersCountResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetUsersCountResult>> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new GetUsersCountResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            _statisticsRepository.GetUsersCount());
    }
}
