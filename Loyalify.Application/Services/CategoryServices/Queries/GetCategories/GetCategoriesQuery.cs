using ErrorOr;
using MediatR;

namespace Loyalify.Application.Services.CategoryServices.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<ErrorOr<GetCategoriesResult>>;
