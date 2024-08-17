using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveStoresCount;

public record GetActiveStoresCountQuery() :
    IRequest<ErrorOr<GetActiveStoresCountResult>>;
