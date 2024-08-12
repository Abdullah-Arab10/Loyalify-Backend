using Loyalify.Application.Services.PointsServices.Commands.AddPoints;
using Loyalify.Application.Services.PointsServices.Queries.GetUserPointsp;
using Loyalify.Contracts.Offer;
using Loyalify.Contracts.Points;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

[Route("Points")]
public class PointsController (
    IMapper mapper,
    ISender mediator): ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    [HttpGet]
    [Route("GetUserPoints/{userId}")]
    public async Task<IActionResult> GetUserPoints(Guid userId)
    {
        var authResult = await _mediator.Send(new GetUserPointsQuery(userId));
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetUserPointsResponse>(authResult)),
            Problem);
    }
    [HttpPut]
    [Route("AddPoints")]
    public async Task<IActionResult> AddPoints(AddPointsRequest request)
    {
        var command = _mapper.Map<AddPointsCommand>(request);
        var authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<TakeOfferResponse>(authResult)),
            Problem);
    }
}
