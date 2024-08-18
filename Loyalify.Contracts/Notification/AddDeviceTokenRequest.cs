namespace Loyalify.Contracts.Notification;

public class AddDeviceTokenRequest
{
    public Guid Id { get; set; }
    public string DeviceToken { get; set; } = null!;
}
