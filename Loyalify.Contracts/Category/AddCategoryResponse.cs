using System.Net;

namespace Loyalify.Contracts.Category;

public class AddCategoryResponse
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; } = null!;
}
