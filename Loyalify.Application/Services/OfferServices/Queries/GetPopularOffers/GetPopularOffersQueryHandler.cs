using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetPopularOffers;

public class GetPopularOffersQueryHandler(IOfferRepository offerRepository) :
    IRequestHandler<GetPopularOffersQuery, ErrorOr<GetPopularOffersResult>>
{
    private readonly IOfferRepository _offerRepository = offerRepository;
    public async Task<ErrorOr<GetPopularOffersResult>> Handle(GetPopularOffersQuery request, CancellationToken cancellationToken)
    {
        var offers = await _offerRepository.GetPopularOffers();
        return new GetPopularOffersResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            offers);
    }
}
