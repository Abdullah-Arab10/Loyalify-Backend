using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.CategoryServices.Commands.AddCategory;

public record AddCategoryCommand(
    string Name,
    string Logo) : IRequest<ErrorOr<AddCategoryResult>>;
        