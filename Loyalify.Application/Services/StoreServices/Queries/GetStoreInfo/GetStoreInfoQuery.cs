using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;

public record GetStoreInfoQuery(int StoreId):IRequest<ErrorOr<GetStoreInfoResult>>;

