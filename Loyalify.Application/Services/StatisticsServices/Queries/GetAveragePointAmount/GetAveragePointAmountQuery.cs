using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetAveragePointAmount;

public record GetAveragePointAmountQuery():
    IRequest<ErrorOr<GetAveragePointAmountResult>>;
