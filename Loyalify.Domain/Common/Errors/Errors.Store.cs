using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class Store
    {
        public static Error NoStores => Error.NotFound(
            description: "No stores found");
    }
}
