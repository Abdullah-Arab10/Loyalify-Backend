namespace Loyalify.Contracts.Offer;

public class GetOfferDetailsRequest
{
    public Guid UserId { get; set; }
    public Guid OfferId { get; set; }
}
