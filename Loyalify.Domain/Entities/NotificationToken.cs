namespace Loyalify.Domain.Entities;

public class NotificationToken
{
    public User User { get; set; } = null!;
    public string DeviceToken { get; set; } = null!;
}
