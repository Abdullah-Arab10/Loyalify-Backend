using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalify.Domain.Entities;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    private decimal _pointRatio;
    public decimal PointRatio
    {
        get { return _pointRatio; }
        set { _pointRatio = value / 100; }
    }
    public StoreCategory Category { get; set; } = null!;
    public string? CoverImage { get; set; }
    public string? StoreImage { get; set; }
    public bool IsActive { get; set; }
}
