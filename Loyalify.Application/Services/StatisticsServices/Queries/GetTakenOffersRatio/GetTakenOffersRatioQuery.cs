using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.StatisticsServices.Queries.GetTakenOffersRatio;

public record GetTakenOffersRatioQuery():
    IRequest<ErrorOr<GetTakenOffersRatioResult>>;
