using Loyalify.Domain.Entities;
using System.Net;

namespace Loyalify.Application.Services.CategoryServices.Queries.GetCategories;

public record GetCategoriesResult(
    HttpStatusCode Status,
    List<StoreCategory> Categories);
