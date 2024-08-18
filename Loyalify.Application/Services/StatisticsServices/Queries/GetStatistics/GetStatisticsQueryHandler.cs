using ErrorOr;
using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;


namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStatistics;

public class GetStatisticsQueryHandler(
    IStatisticsRepository statisticsRepository) :
IRequestHandler<GetStatisticsQuery, ErrorOr<GetStatisticsResult>>
{
    private readonly IStatisticsRepository _statisticsRepository = statisticsRepository;
    public async Task<ErrorOr<GetStatisticsResult>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var statistics =
            new GetStatisticsDTO
            {

                activeOffers = _statisticsRepository.GetActiveOffersCount(),
                activeStores = _statisticsRepository.GetActiveStoresCount(),
                totalOffers = _statisticsRepository.GetOffersCount(),
                totalStores = _statisticsRepository.GetStoresCount(),
                userCount = _statisticsRepository.GetUsersCount(),
                averagePointAmount = _statisticsRepository.GetAveragePointAmount(),
                takenOffersRatio = _statisticsRepository.GetTakenOffersRatio(),
                totalPointsUsed = _statisticsRepository.GetTotalPointsUsed(),

            };

        return new GetStatisticsResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            statistics);
    }
}
