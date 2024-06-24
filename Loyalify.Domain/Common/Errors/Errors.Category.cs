using ErrorOr;

namespace Loyalify.Domain.Common.Errors;

public static partial class Errors
{
    public static class Category
    {
        public static Error CategoryNotExisted=> Error.NotFound(
            description: "Category doesn't exist");
    }
}
