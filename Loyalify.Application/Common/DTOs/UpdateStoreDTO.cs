namespace Loyalify.Application.Common.DTOs;

public class UpdateStoreDTO
{
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Address { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string? StoreImage { get; set; }
    public string? CoverImage { get; set; }
}
