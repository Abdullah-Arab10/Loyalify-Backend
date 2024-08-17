using Loyalify.Application.Services.StatisticsServices.Queries.GetActiveOffersCount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetActiveStoresCount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetAveragePointAmount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetOffersCount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetStoresCount;
using Loyalify.Application.Services.StatisticsServices.Queries.GetTakenOffersRatio;
using Loyalify.Application.Services.StatisticsServices.Queries.GetTotalPointsUsed;
using Loyalify.Application.Services.StatisticsServices.Queries.GetUsersCount;
using Loyalify.Contracts.Statistics;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;
[Route("Statistics")]
public class StatisticsController(
    IMapper mapper,
    ISender mediator) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    [HttpGet]
    [Route("GetStoresCount")]
    public async Task<IActionResult> GetStoresCount()
    {
        var authResult = await _mediator.Send(new GetStoresCountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCountResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetActiveStoresCount")]
    public async Task<IActionResult> GetActiveStoresCount()
    {
        var authResult = await _mediator.Send(new GetActiveStoresCountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCountResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetOffersCount")]
    public async Task<IActionResult> GetOffersCount()
    {
        var authResult = await _mediator.Send(new GetOffersCountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCountResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetActiveOffersCount")]
    public async Task<IActionResult> GetActiveOffersCount()
    {
        var authResult = await _mediator.Send(new GetActiveOffersCountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCountResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetUsersCount")]
    public async Task<IActionResult> GetUsersCount()
    {
        var authResult = await _mediator.Send(new GetUsersCountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCountResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetTakenOffersRatio")]
    public async Task<IActionResult> GetTakenOffersRatio()
    {
        var authResult = await _mediator.Send(new GetTakenOffersRatioQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetRatioResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetTotalPointsUsed")]
    public async Task<IActionResult> GetTotalPointsUsed()
    {
        var authResult = await _mediator.Send(new GetTotalPointsUsedQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetPointsResponse>(authResult)),
            Problem);
    }
    [HttpGet]
    [Route("GetAveragePointAmount")]
    public async Task<IActionResult> GetAveragePointAmount()
    {
        var authResult = await _mediator.Send(new GetAveragePointAmountQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetPointsResponse>(authResult)),
            Problem);
    }
}
