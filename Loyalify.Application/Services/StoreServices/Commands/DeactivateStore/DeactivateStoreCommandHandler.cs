using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.DeactivateStore;

public class DeactivateStoreCommandHandler(
    IStoreRepository storeRepository,
    IUserRepository userRepository) :
    IRequestHandler<DeactivateStoreCommand, ErrorOr<DeactivateStoreResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<ErrorOr<DeactivateStoreResult>> Handle(DeactivateStoreCommand request, CancellationToken cancellationToken)
    {
        //var userId = await _storeRepository.GetStoreUser(request.Id);
        await _userRepository.BlockUser(request.Id);
        bool state = await _storeRepository.DeactivateStore(request.Id);
        if (state)
        {
            return new DeactivateStoreResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Store activated");
        }
        else
        {
            return new DeactivateStoreResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Store deactivated");
        }
    }
}
