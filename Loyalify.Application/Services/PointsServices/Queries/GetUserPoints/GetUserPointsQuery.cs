using ErrorOr;
using Loyalify.Application.Services.PointsServices.Queries.GetUserPoints;
using MediatR;


namespace Loyalify.Application.Services.PointsServices.Queries.GetUserPointsp;

public record GetUserPointsQuery(Guid userId):IRequest<ErrorOr<GetUserPointsResult>>;

