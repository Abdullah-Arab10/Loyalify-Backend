using Loyalify.Application.Services.StatisticsServices.Queries.GetStatistics;
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
    [Route("GetStatistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var authResult = await _mediator.Send(new GetStatisticsQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetStatisticsResponse>(authResult)),
            Problem);
    }

  
}
