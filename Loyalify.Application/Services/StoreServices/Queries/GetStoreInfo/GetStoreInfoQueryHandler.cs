using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Loyalify.Domain.Common.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;

public class GetStoreInfoQueryHandler(IStoreRepository storeRepository) : IRequestHandler<GetStoreInfoQuery, ErrorOr<GetStoreInfoResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;

    public async Task<ErrorOr<GetStoreInfoResult>> Handle(GetStoreInfoQuery request, CancellationToken cancellationToken)
    {
       var Store = await _storeRepository.GetStoreInfo(request.StoreId);
        if (Store == null)
        {
            return Errors.Store.NoStores;
        }
        return new GetStoreInfoResult((HttpStatusCode)StatusCodes.Status200OK,Store);
    }
}
