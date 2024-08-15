using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;

public class GetPopularStoresQueryHandler(IStoreRepository storeRepository):
    IRequestHandler<GetPopularStoresQuery, ErrorOr<GetPopularStoresResult>>
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    public async Task<ErrorOr<GetPopularStoresResult>> Handle(GetPopularStoresQuery request, CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.GetPopularStores();
        return new GetPopularStoresResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            stores);
    }
}
