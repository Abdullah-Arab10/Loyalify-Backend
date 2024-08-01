using Loyalify.Application.Common.DTOs;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;

public record GetAllOffersUserResult(
    HttpStatusCode Status,
    List<OffersListUserDTO> Items);
