using System.Net;

namespace Loyalify.Contracts.Offer;

public class GetAllOffersResponse
{
    public HttpStatusCode Status { get; set; }
    public List<object> Items { get; set; } = [];
}
