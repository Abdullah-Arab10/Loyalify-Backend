using System.Net;

namespace Loyalify.Contracts.Statistics;

public class GetRatioResponse
{
    public HttpStatusCode Status { get; set; }
    public decimal Ratio { get; set; }
}
