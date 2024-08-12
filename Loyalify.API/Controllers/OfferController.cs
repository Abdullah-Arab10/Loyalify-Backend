using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Application.Services.OfferServices.Commands.AddOffer;
using Loyalify.Application.Services.OfferServices.Commands.TakeOffer;
using Loyalify.Application.Services.OfferServices.Queries.GetAllOffersUser;
using Loyalify.Application.Services.OfferServices.Queries.GetOfferDetails;
using Loyalify.Application.Services.OfferServices.Queries.GetStoreOffers;
using Loyalify.Contracts.Offer;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

[Route("Offer")]
public class OfferController(
    IPhotoService photoService,
    ISender mediator,
    IMapper mapper) : ApiController
{
    private readonly IPhotoService _photoService = photoService;
    private readonly ISender _mediator = mediator; 
    private readonly IMapper _mapper = mapper;
    [HttpPost]
    [Route("AddOffer")]
    public async Task<IActionResult> AddOffer([FromForm]AddOfferRequest request)
    {
        string image = null!;
        if (request.ImageFile != null)
        {
            var fileResult = _photoService.SaveImage(request.ImageFile);
            image = fileResult;
        }
        var command = new AddOfferCommand(
            request.Name,
            request.Description,
            request.PointAmount,
            request.StoreId,
            request.ExpiresIn,
            image);
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<AddOfferResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetAllOffersUser")]
    public async Task<IActionResult> GetAllOffersUser(int Page = 1)
    {
        var authResult = await _mediator.Send(new GetAllOffersUserQuery(Page));
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetAllOffersResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetStoreOffers/{Id}")]
    public async Task<IActionResult> GetStoreOffers(int Id)
    {
        var authResult = await _mediator.Send(new GetStoreOffersQuery(Id));
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetAllOffersResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetOfferDetails")]
    public async Task<IActionResult> GetOfferDetails([FromQuery] GetOfferDetailsRequest request)
    {
        var query = _mapper.Map<GetOfferDetailsQuery>(request);
        var authResult = await _mediator.Send(query);
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetOfferDetailsResponse>(authResult)),
            Problem);
    }
    [HttpPost]
    [Route("TakeOffer")]
    public async Task<IActionResult> TakeOffer([FromQuery] GetOfferDetailsRequest request)
    {
        var command = _mapper.Map<TakeOfferCommand>(request);
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<TakeOfferResponse>(authResult)),
            Problem);
    }
}
