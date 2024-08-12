namespace Loyalify.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Offer? Offer { get; set; }
    public User? User { get; set; }
    public DateTime Date { get; set; }
}
