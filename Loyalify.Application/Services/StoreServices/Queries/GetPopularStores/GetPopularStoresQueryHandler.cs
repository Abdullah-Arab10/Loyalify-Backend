using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;

public class GetPopularStoresQueryHandler :
    IRequestHandler<GetPopularStoresQuery, ErrorOr<GetPopularStoresResult>>
{
    public Task<ErrorOr<GetPopularStoresResult>> Handle(GetPopularStoresQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
