using ErrorOr;
using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.SeeStoresList;

public class SeeStoresListQueryHandler(IStoreRepository storeRepository) :
    IRequestHandler<SeeStoresListQuery, ErrorOr<SeeStoresListResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<SeeStoresListResult>> Handle(SeeStoresListQuery request, CancellationToken cancellationToken)
    {
        List<StoresListDTO> stores = await _storeRepository.GetStores(request.CategoryId);
        return new SeeStoresListResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            stores);
    }
}
