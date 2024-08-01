using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetStoreOffers;

public class GetStoreOffersQueryHandler (IOfferRepository offerRepository):
    IRequestHandler<GetStoreOffersQuery, ErrorOr<GetStoreOffersResult>>
{
    private readonly IOfferRepository _offerRepository = offerRepository;
    public async Task<ErrorOr<GetStoreOffersResult>> Handle(GetStoreOffersQuery request, CancellationToken cancellationToken)
    {
        var offers = await _offerRepository.GetStoreOffers(request.Id);
        if (offers.Count == 0)
        {
            return Errors.Offer.NoOffers;
        }
        return new GetStoreOffersResult(
            (HttpStatusCode)StatusCodes.Status200OK, offers);
    }
}
