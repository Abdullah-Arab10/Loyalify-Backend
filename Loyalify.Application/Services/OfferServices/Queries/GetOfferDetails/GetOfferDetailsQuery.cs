using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Queries.GetOfferDetails;

public record GetOfferDetailsQuery(
    Guid UserId,
    Guid OfferId): IRequest<ErrorOr<GetOfferDetailsResult>>;
