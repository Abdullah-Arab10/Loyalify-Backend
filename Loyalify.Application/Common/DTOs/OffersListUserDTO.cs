namespace Loyalify.Application.Common.DTOs;

public class OffersListUserDTO
{
    public Guid Id { get; set; }
    public string OfferName { get; set; } = null!;
    public string? OfferImage { get; set; }
    public string StoreName { get; set; } = null!;
    public string? StoreImage { get; set; }
    public int PointAmount { get; set; }
}
