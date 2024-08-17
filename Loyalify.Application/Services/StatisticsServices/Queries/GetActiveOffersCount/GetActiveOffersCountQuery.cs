using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetActiveOffersCount;

public record GetActiveOffersCountQuery(): IRequest<ErrorOr<GetActiveOffersCountResult>>;
