using System.Net;

namespace Loyalify.Contracts.Statistics;

public class GetCountResponse
{
    public HttpStatusCode Status { get; set; }
    public int Count { get; set; }
}
