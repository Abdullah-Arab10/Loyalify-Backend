using System.Net;

namespace Loyalify.Contracts.Offer;

public class AddOfferResponse
{
    public HttpStatusCode Status { get; set; } = HttpStatusCode.Created;
    public string Message { get; set; } = string.Empty;
}
