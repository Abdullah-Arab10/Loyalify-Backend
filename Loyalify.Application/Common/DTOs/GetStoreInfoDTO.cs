using Loyalify.Domain.Entities;

namespace Loyalify.Application.Common.DTOs;

public class GetStoreInfoDTO
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CategoryId { get; set; }
    public Guid UserId { get; set; } 
    public string? CoverImage { get; set; }
    public string? StoreImage { get; set; }
    public bool IsActive { get; set; }

}
