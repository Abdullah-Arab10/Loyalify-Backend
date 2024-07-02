using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.CategoryServices.Commands.AddCategory;

public record AddCategoryCommand(
    string Name) : IRequest<ErrorOr<AddCategoryResult>>;
        