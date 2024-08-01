using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Queries.GetStoreOffers;

public record GetStoreOffersQuery(int Id) : IRequest<ErrorOr<GetStoreOffersResult>>;
