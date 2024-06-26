using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.SeeStoresList;

public record SeeStoresListQuery(int CategoryId) : IRequest<ErrorOr<SeeStoresListResult>>;
