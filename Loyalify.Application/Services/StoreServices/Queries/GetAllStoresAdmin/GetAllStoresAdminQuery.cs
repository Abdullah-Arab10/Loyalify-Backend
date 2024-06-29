using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresAdmin;

public record GetAllStoresAdminQuery(
    int CategoryId,
    string Search) : IRequest<ErrorOr<GetAllStoresAdminResult>>;
