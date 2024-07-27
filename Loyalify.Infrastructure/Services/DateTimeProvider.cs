using Loyalify.Application.Common.Interfaces.Services;

namespace Loyalify.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}
