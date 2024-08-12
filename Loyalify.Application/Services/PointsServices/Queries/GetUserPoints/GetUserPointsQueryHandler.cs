using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Application.Services.PointsServices.Queries.GetUserPointsp;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.PointsServices.Queries.GetUserPoints;

public class GetUserPointsQueryHandler(IPointsRepository pointsRepository) : IRequestHandler<GetUserPointsQuery,ErrorOr<GetUserPointsResult>>
{
    private readonly IPointsRepository _pointsRepository = pointsRepository;
    public async Task<ErrorOr<GetUserPointsResult>> Handle(GetUserPointsQuery request, CancellationToken cancellationToken) 
    {
        var points = await _pointsRepository.GetUserPoints(request.userId);
        return new GetUserPointsResult((HttpStatusCode)StatusCodes.Status200OK,points);
    }
}
