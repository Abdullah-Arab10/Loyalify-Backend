using ErrorOr;
using Loyalify.Application.Common.DTOs;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;

public class GetAllStoresUserQueryHandler(IStoreRepository storeRepository) :
    IRequestHandler<GetAllStoresUserQuery, ErrorOr<GetAllStoresUserResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<GetAllStoresUserResult>> Handle(GetAllStoresUserQuery request, CancellationToken cancellationToken)
    {
        List<StoresListUserDTO> stores =
            await _storeRepository.GetStoresUser(request.CategoryId, request.Search);
        if (stores.Count == 0)
        {
            return Errors.Store.NoStores;
        }
        return new GetAllStoresUserResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            stores);
    }
}
