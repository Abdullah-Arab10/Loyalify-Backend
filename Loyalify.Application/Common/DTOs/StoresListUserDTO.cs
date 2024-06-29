namespace Loyalify.Application.Common.DTOs;

public class StoresListUserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string? StoreImage { get; set; }
}
