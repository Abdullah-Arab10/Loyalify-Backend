using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.OfferServices.Commands.AddOffer;

public record AddOfferCommand(
    string Name,
    string Description,
    int PointAmount,
    int StoreId,
    int ExpiresIn,
    string Image) : IRequest<ErrorOr<AddOfferResult>>;
