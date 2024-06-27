using System.Net;

namespace Loyalify.Contracts.Store;

public class DeactivateStoreResponse
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; } = null!;
}
