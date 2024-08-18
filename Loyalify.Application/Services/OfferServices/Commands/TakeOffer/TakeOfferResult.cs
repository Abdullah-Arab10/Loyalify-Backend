using System.Net;

namespace Loyalify.Application.Services.OfferServices.Commands.TakeOffer;

public record TakeOfferResult(
    HttpStatusCode Status,
    string Message,
    string DeviceToken);
