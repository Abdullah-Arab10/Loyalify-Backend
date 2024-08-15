using Loyalify.Domain.Entities;
using System.Text.Json.Serialization;

namespace Loyalify.Application.Common.DTOs;

public class GetStoreInfoDTO
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int CategoryId { get; set; }
    public string? CoverImage { get; set; }
    public string? StoreImage { get; set; }
    [JsonIgnore]
    public bool IsActive { get; set; }
    public string State => IsActive ? "Active" : "Inactive";
}
