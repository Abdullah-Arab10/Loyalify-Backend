using Microsoft.AspNetCore.Http;

namespace Loyalify.Contracts.Category;

public class AddCategoryRequest
{
    public string Name { get; set; } = null!;
    //public IFormFile? Logo { get; set; }
}
