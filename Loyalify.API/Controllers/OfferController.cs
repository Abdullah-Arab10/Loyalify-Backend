using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Application.Services.OfferServices.Commands.AddOffer;
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
}
