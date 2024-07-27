using Microsoft.AspNetCore.Http;

namespace Loyalify.Contracts.Offer;

public class AddOfferRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int PointAmount { get; set; }
    public int StoreId { get; set; }
    public int ExpiresIn { get; set; }
    public IFormFile? ImageFile { get; set; }
}
