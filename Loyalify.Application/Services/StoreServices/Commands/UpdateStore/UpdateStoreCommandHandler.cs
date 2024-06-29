using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Commands.UpdateStore;

public class UpdateStoreCommandHandler(IStoreRepository storeRepository) :
    IRequestHandler<UpdateStoreCommand, ErrorOr<UpdateStoreResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<UpdateStoreResult>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
    {
        await _storeRepository.Update(request.Store,request.Id);
        return new UpdateStoreResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Store updated");
    }
}
