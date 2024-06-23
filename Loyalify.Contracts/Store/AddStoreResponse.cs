using System.Net;

namespace Loyalify.Contracts.Store;

public class AddStoreResponse
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Created;
    public string Message { get; set; } = string.Empty;
}
