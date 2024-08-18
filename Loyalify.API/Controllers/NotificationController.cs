using FirebaseAdmin.Messaging;
using Loyalify.Application.Services.NotificationServices.Commands.AddDeviceToken;
using Loyalify.Contracts.Category;
using Loyalify.Contracts.Notification;
using Loyalify.Contracts.Offer;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

public class NotificationController(
    IMapper mapper,
    ISender mediator): ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    [HttpPost]
    [Route("AddDeviceToken")]
    public async Task<IActionResult> AddDeviceToken(AddDeviceTokenRequest request)
    {
        var command = _mapper.Map<AddDeviceTokenCommand>(request);
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<AddCategoryResponse>(authResult)),
            Problem);
    }
}
