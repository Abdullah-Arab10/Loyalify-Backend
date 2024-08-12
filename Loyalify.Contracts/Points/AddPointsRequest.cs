namespace Loyalify.Contracts.Points;

public class AddPointsRequest
{
    public Guid UserId { get; set; }
    public Guid StoreManagerId { get; set; }
    public decimal Bill { get; set; }
}
