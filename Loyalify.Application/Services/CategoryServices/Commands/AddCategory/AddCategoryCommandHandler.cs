using ErrorOr;
using Loyalify.Application.Common.Interfaces.Persistence;
using Loyalify.Domain.Common.Errors;
using Loyalify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Loyalify.Application.Services.CategoryServices.Commands.AddCategory;

public class AddCategoryCommandHandler(ICategoryRepository categoryRepository) :
    IRequestHandler<AddCategoryCommand, ErrorOr<AddCategoryResult>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<ErrorOr<AddCategoryResult>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategory(request.Name);
        if (category is not null)
        {
            return Errors.Category.CategoryExist;
        }
        var newCategory = new StoreCategory()
        {
            Name = request.Name
        };
        await _categoryRepository.Add(newCategory);
        return new AddCategoryResult(
            (HttpStatusCode)StatusCodes.Status200OK,
            "Category has been added successfully");
    }
}
