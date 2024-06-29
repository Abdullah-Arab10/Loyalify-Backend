namespace Loyalify.Application.Common.DTOs;

public class StoresListAdminDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Guid UserId { get; set; }
    public int CategoryId { get; set; }
    public string? StoreImage { get; set; }
    public string? CoverImage { get; set; }
    public bool IsActive { get; set; }
}
