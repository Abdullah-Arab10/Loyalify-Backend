using ErrorOr;
using Hangfire;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.OfferServices.Commands.AddOffer;

public class AddOfferCommandHandler(
    IOfferRepository offerRepository,
    IDateTimeProvider dateTimeProvider)
    : IRequestHandler<AddOfferCommand, ErrorOr<AddOfferResult>>
{
    private readonly IOfferRepository _offerRepository = offerRepository;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    public async Task<ErrorOr<AddOfferResult>> Handle(AddOfferCommand command, CancellationToken cancellationToken)
    {
        var store = _offerRepository.GetOfferStore(command.StoreId).Result;
        if (store == null)
        {
            return Errors.Store.NoStores;
        }
        var offer = new Offer()
        {
            Name = command.Name,
            Description = command.Description,
            PointAmount = command.PointAmount,
            Store = store,
            CreatedAt = _dateTimeProvider.Now,
            Deadline = _dateTimeProvider.Now.AddMinutes(command.ExpiresIn),
            Image = command.Image,
        };
        await _offerRepository.Add(offer);
        BackgroundJob.Schedule(
            () => _offerRepository.UpdateIsActive(offer.Id),
            TimeSpan.FromMinutes(command.ExpiresIn));
        return new AddOfferResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Offer created successfully");
    }
}
