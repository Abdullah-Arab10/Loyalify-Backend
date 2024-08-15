using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Queries.GetPopularOffers;

public record GetPopularOffersQuery(): IRequest<ErrorOr<GetPopularOffersResult>>;
