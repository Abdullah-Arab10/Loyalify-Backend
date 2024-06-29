namespace Loyalify.Contracts.Store;

public class SeeStoresListRequest
{
    public int CategoryId { get; set; }
    public string? Search { get; set; }
}
