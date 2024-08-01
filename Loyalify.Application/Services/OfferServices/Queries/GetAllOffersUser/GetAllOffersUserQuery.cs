using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;

public record GetAllOffersUserQuery(int Page) : IRequest<ErrorOr<GetAllOffersUserResult>>;
