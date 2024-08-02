using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetOfferDetails;

public record GetOfferDetailsResult(
    HttpStatusCode Status,
    OfferDetailsDTO Items);
