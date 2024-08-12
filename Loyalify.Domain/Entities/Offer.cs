namespace Loyalify.Domain.Entities;

public class Offer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal PointAmount { get; set; }
    public Store Store { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Image { get; set; }
}
