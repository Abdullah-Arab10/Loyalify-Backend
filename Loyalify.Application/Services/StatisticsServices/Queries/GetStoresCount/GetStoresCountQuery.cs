using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetStoresCount;

public record GetStoresCountQuery() : IRequest<ErrorOr<GetStoresCountResult>>;
