using ErrorOr;
using Loyalify.Application.Common.Interfaces.Services;
using Loyalify.Application.Services.CategoryServices.Commands.AddCategory;
using Loyalify.Application.Services.CategoryServices.Queries.GetCategories;
using Loyalify.Contracts.Category;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loyalify.API.Controllers;

[Route("Category")]
//[Authorize(Roles = "Admin")]
public class CategoryController(
    IMapper mapper,
    ISender mediator,
    IPhotoService photoService) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    private readonly IPhotoService _photoService = photoService;
    [HttpGet]
    [Route("GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        var authResult = await _mediator.Send(new GetCategoriesQuery());
        return authResult.Match(
            authResult => Ok(_mapper.Map<GetCategoriesResponse>(authResult)),
            Problem);
    }
    [HttpPost]
    [Route("AddCategory")]
    public async Task<IActionResult> AddCategory([FromForm] AddCategoryRequest request)
    {
        string logo = null!;
      
        var command = new AddCategoryCommand(request.Name);
        ErrorOr<AddCategoryResult> authResult = await _mediator.Send(command);
        return authResult.Match(
            authResult => Ok(_mapper.Map<AddCategoryResponse>(authResult)),
            Problem);
    }
}
