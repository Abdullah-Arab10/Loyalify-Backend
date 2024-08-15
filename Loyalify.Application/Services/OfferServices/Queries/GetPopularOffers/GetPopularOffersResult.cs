using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetPopularOffers;

public record GetPopularOffersResult(
    HttpStatusCode Status,
    List<OffersListUserDTO> Items);
