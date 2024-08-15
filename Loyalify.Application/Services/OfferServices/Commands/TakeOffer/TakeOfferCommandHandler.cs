using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Commands.TakeOffer;

public class TakeOfferCommandHandler(
    IPointsRepository pointsRepository,
    IOfferRepository offerRepository,
    IUserRepository userRepository,
    IDateTimeProvider dateTimeProvider):
    IRequestHandler<TakeOfferCommand, ErrorOr<TakeOfferResult>>
{
    private readonly IPointsRepository _pointsRepository = pointsRepository;
    private readonly IOfferRepository _offerRepository = offerRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    public async Task<ErrorOr<TakeOfferResult>> Handle(TakeOfferCommand request, CancellationToken cancellationToken)
    {
        if (_offerRepository.OfferAlreadyTaken(request.UserId,request.OfferId))
        {
            return Errors.Offer.OfferAlreadyTaken;
        };
        var offer = _offerRepository.GetOfferById(request.OfferId).Result;
        if (_dateTimeProvider.Now > offer!.Deadline)
        {
            return Errors.Offer.OfferExpired;
        }
        var user = _userRepository.GetUserById(request.UserId).Result;
        if(!user!.IsActive)
        {
            return Errors.Authentication.DeactivatedEmail;
        }
        var transaction = new Transaction() 
        {
            Offer = offer,
            User = user,
            Date = _dateTimeProvider.Now,
        };
        await _offerRepository.AddTransaction(transaction);
        if(offer is not null)
        {
            await _pointsRepository.UpdateUserPoints(request.UserId, -offer.PointAmount);
        }
        return new TakeOfferResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Operation completed");
    }
}
