using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetStoreOffers;

public record GetStoreOffersResult(
    HttpStatusCode Status,
    List<OffersListUserDTO> Items);
