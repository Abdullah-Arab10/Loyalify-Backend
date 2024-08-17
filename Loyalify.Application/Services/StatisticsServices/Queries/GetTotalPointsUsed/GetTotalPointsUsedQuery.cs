using ErrorOr;
using Loyalify.Application.Services.StatisticsServices.Queries.GetAveragePointAmount;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTotalPointsUsed;

public record GetTotalPointsUsedQuery(): 
    IRequest<ErrorOr<GetTotalPointsUsedResult>>;
