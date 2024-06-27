using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalify.Domain.Entities;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public StoreCategory Category { get; set; } = null!;
    public User User { get; set; } = null!;
    public string? CoverImage { get; set; }
    public string? StoreImage { get; set; }
    public bool IsActive { get; set; }
}
