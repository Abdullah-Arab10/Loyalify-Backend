using System.Net;

namespace Loyalify.Contracts.Store;

public class GetStoreInfoResponse
{
    public HttpStatusCode Status { get; set; }
    public object Store { get; set; } = null! ;
}
