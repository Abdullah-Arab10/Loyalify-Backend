using ErrorOr;
using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresAdmin;

public class GetAllStoresAdminQueryHandler(IStoreRepository storeRepository) :
    IRequestHandler<GetAllStoresAdminQuery, ErrorOr<GetAllStoresAdminResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<GetAllStoresAdminResult>> Handle(GetAllStoresAdminQuery request, CancellationToken cancellationToken)
    {
        List<StoresListAdminDTO> stores =
            await _storeRepository.GetStoresAdmin(request.CategoryId, request.Search);
        if (stores.Count == 0)
        {
            return Errors.Store.NoStores;
        }
        return new GetAllStoresAdminResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            stores);
    }
}
