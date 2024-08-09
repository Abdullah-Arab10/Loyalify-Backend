using Loyalify.Application.Services.PointsServices.Queries.GetUserPointsp;
using Loyalify.Application.Services.StoreServices.Queries.GetStoreInfo;
using Loyalify.Contracts.Points;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Loyalify.API.Controllers
{
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
            return authResult.Match(authResult => Ok(_mapper.Map<GetUserPointsResponse>(authResult)), Problem);

        }



    }
}
