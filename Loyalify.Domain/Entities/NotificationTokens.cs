namespace Loyalify.Domain.Entities;

public class NotificationTokens
{
    public User User { get; set; } = null!;
    public string DeviceToken { get; set; } = null!;
}
