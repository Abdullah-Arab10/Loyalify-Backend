using System.Net;

namespace Loyalify.Contracts.Statistics;
public class GetStatisticsResponse
{
    public HttpStatusCode Status { get; set; }
    public object? items { get; set; }
}
