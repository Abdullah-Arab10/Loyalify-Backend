using System.Net;

namespace Loyalify.Contracts.Offer;

public class GetOfferDetailsResponse
{
    public HttpStatusCode Status { get; set; }
    public object Items { get; set; } = null!;
}
