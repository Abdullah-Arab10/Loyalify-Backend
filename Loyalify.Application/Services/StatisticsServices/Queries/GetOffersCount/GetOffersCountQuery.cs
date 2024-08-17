using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetOffersCount;

public record GetOffersCountQuery(): IRequest<ErrorOr<GetOffersCountResult>>;
