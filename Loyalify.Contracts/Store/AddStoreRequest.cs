using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Loyalify.Contracts.Store;

public class AddStoreRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StoreManagerEmail { get; set; } = null!;
    public string StoreManagerPassword { get; set; } = null!;
    public string Category { get; set; } = null!;
    public IFormFile? CoverImageFile { get; set; }
    public IFormFile? StoreImageFile { get; set; }
}
