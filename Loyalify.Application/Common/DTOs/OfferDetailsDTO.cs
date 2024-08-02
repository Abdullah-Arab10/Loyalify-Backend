namespace Loyalify.Application.Common.DTOs;

public class OfferDetailsDTO
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Image {  get; set; }
    public int PointAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }
    public decimal UserPoints { get; set; }
}
