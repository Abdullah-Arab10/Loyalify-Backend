using System.Net;

namespace Loyalify.Contracts.Store;

public class SeeStoresListResponse
{
    public HttpStatusCode Status { get; set; }
    public List<object> Items { get; set; } = [];
}
