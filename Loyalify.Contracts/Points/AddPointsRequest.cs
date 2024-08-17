namespace Loyalify.Contracts.Points;

public class AddPointsRequest
{
    public Guid UserId { get; set; }
    public Guid CashierId { get; set; }
    public decimal Bill { get; set; }
}
