using System.Net;

namespace Loyalify.Application.Services.CategoryServices.Commands.AddCategory;

public record AddCategoryResult(
    HttpStatusCode Status,
    string Message);
