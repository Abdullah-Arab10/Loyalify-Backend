using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Queries.GetOfferDetails;

public class GetOfferDetailsQueryHandler(IOfferRepository offerRepository):
    IRequestHandler<GetOfferDetailsQuery, ErrorOr<GetOfferDetailsResult>>
{
    private readonly IOfferRepository _offerRepository = offerRepository;
    public async Task<ErrorOr<GetOfferDetailsResult>> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new GetOfferDetailsResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            _offerRepository.GetOfferDetails(request.UserId, request.OfferId));
    }
}
