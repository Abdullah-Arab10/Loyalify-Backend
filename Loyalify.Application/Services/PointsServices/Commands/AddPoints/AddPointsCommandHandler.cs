using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.PointsServices.Commands.AddPoints;

public class AddPointsCommandHandler(
    IStoreRepository storeRepository,
    IPointsRepository pointsRepository):
    IRequestHandler<AddPointsCommand, ErrorOr<AddPointsResult>>
{
    private readonly IPointsRepository _pointsRepository = pointsRepository;
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<AddPointsResult>> Handle(AddPointsCommand request, CancellationToken cancellationToken)
    {
        var ratio = _storeRepository.GetStorePointRatio(request.StoreManagerId).Result;
        if(!_storeRepository.StoreIsActive(request.StoreManagerId).Result)
        {
            return Errors.Store.StoreDeactivated;
        }
        var points = ratio * request.Bill;
        await _pointsRepository.UpdateUserPoints(request.UserId,points);
        return new AddPointsResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Points added to the user");
    }
}
