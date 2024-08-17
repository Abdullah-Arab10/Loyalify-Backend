namespace Loyalify.Contracts.Notification;

public class MessageRequest
{
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public string DeviceToken { get; set; } = null!;
}
