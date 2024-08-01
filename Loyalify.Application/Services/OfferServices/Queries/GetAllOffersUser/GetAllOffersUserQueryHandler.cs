using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;

public class GetAllOffersUserQueryHandler
    (IOfferRepository offerRepository) : IRequestHandler<GetAllOffersUserQuery, ErrorOr<GetAllOffersUserResult>>
{
    private readonly IOfferRepository _offerRepository = offerRepository;
    public async Task<ErrorOr<GetAllOffersUserResult>> Handle(GetAllOffersUserQuery request, CancellationToken cancellationToken)
    {
        var offers = await _offerRepository.GetAllOffersUser(request.Page);
        if (offers.Count == 0)
        {
            return Errors.Offer.NoOffers;
        }
        return new GetAllOffersUserResult(
            (HttpStatusCode)StatusCodes.Status200OK, offers);
    }
}
