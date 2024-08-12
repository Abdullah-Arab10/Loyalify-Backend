namespace Loyalify.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Offer? Offer { get; set; } = null!;
    public User? User { get; set; } = null!;
    public DateTime Date { get; set; }
}
