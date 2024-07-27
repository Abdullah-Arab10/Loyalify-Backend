using System.Net;

namespace Loyalify.Application.Services.OfferServices.Commands.AddOffer;

public record AddOfferResult(
    HttpStatusCode Status,
    string Message);
