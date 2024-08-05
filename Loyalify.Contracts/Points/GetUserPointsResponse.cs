using System.Net;

namespace Loyalify.Contracts.Points;

public class GetUserPointsResponse
{
    public HttpStatusCode Status { get; set; }
    public decimal Points { get; set; } = 0!;
}
