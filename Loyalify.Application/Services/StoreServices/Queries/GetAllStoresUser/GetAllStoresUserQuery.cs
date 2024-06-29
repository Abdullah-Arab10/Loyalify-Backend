using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.GetAllStoresUser;

public record GetAllStoresUserQuery(
    int CategoryId,
    string Search) : IRequest<ErrorOr<GetAllStoresUserResult>>;
