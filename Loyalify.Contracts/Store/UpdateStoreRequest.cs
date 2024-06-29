using Microsoft.AspNetCore.Http;

namespace Loyalify.Contracts.Store;

public class UpdateStoreRequest
{
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public int CategoryId { get; set; } = 0;
    public IFormFile? CoverImageFile { get; set; }
    public IFormFile? StoreImageFile { get; set; }
}
