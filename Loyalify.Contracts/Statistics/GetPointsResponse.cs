using System.Net;

namespace Loyalify.Contracts.Statistics;

public class GetPointsResponse
{
    public HttpStatusCode Status { get; set; }
    public decimal Points { get; set; }
}
