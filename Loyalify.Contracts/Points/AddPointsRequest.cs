namespace Loyalify.Contracts.Points;

public class AddPointsRequest
{
    public Guid UserId { get; set; }
    public int StoreId { get; set; }
    public decimal Bill { get; set; }
}
