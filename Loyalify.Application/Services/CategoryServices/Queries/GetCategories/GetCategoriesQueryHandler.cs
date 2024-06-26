using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.CategoryServices.Queries.GetCategories;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) :
    IRequestHandler<GetCategoriesQuery, ErrorOr<GetCategoriesResult>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<ErrorOr<GetCategoriesResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var Categories = await _categoryRepository.GetCategories();
        return new GetCategoriesResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            Categories);
    }
}
