using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.GetPopularStores;

public record GetPopularStoresQuery() : IRequest<ErrorOr<GetPopularStoresResult>>;
