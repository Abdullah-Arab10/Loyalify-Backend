using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetUsersCount;

public record GetUsersCountQuery(): IRequest<ErrorOr<GetUsersCountResult>>;
