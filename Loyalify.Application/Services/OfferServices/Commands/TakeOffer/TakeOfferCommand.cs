using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Commands.TakeOffer;

public record TakeOfferCommand(
    Guid UserId,
    Guid OfferId): IRequest<ErrorOr<TakeOfferResult>>;
